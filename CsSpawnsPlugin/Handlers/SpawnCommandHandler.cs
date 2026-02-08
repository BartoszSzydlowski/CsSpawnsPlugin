using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin.Handlers;
public class SpawnCommandHandler : ISpawnCommandHandler
{
	public Dictionary<int, Vector> TSpawnCoordinates { get; set; } = [];
	public Dictionary<int, Vector> CTSpawnCoordinates { get; set; } = [];

	public void Handle(CCSPlayerController? player, CommandInfo command, ILogger logger)
	{
		logger.LogInformation("Spawn counts — T: {TCount}, CT: {CTCount}", TSpawnCoordinates.Count, CTSpawnCoordinates.Count);
		if (player?.IsValid != true) return;

		if (!CheckCommandArgCount(player, command)) return;

		var pawn = player.PlayerPawn.Value;
		if (pawn == null) return;

		var team = player.Team;
		logger.LogInformation("Player team: {playerTeam}", player.Team);
		var selectedSpawn = GetSpawnInserted(player, command);
		var vector = GetSpawnVector(team, selectedSpawn, logger);

		if (vector == null)
		{
			logger.LogInformation("Invalid spawn number {spawn}", selectedSpawn);
			return;
		}
		pawn.Teleport(vector);
	}

	private static bool CheckCommandArgCount(CCSPlayerController? player, CommandInfo command)
	{
		if (command.ArgCount != 2)
		{
			player?.PrintToChat("Usage: .spawn <number>");
			return false;
		}
		return true;
	}

	private static int GetSpawnInserted(CCSPlayerController? player, CommandInfo command)
	{
		var spawnFromCommand = command.GetArg(1);
		if (!int.TryParse(spawnFromCommand, out int spawnPosition))
		{
			player?.PrintToChat("Usage: .spawn <number>");
			return 0;
		}
		return spawnPosition;
	}

	private static Vector? GetSpawnCoordinates(int selectedSpawn, Dictionary<int, Vector> spawns)
	{
		if (!spawns.TryGetValue(selectedSpawn, out var vector)) return null;
		return vector;
	}

	private Vector? GetSpawnVector(CsTeam team, int selectedSpawn, ILogger logger)
	{
		Dictionary<int, Vector>? dictionary;

		if (team == CsTeam.Terrorist) dictionary = TSpawnCoordinates;
		else if (team == CsTeam.CounterTerrorist) dictionary = CTSpawnCoordinates;
		else return null;

		logger.LogInformation("Returned spawns: {spawns}", (object?)dictionary ?? "none");

		return GetSpawnCoordinates(selectedSpawn, dictionary);
	}
}
