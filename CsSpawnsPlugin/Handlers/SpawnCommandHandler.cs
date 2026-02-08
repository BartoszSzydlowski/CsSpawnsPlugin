using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin.Handlers;
public class SpawnCommandHandler : ISpawnCommandHandler
{
	public Dictionary<int, Vector> TSpawnCoordinates { get; set; } = [];
	public Dictionary<int, Vector> CTSpawnCoordinates { get; set; } = [];
	public string MapName { get; set; } = string.Empty;

	public void Handle(CCSPlayerController? player, CommandInfo command, ILogger logger)
	{
		if (player?.IsValid != true) return;

		if (!CheckCommandArgCount(player, command)) return;

		var pawn = player.PlayerPawn.Value;
		if (pawn == null) return;

		var team = player.Team;
		var selectedSpawn = GetSpawnInserted(player, command);
		var vector = GetSpawnVector(team, selectedSpawn);

		if (vector == null)
		{
			player?.PrintToChat($"Invalid spawn number {selectedSpawn}." +
				$"Possible spawns range for map '{MapName}': " +
				$"T: {TSpawnCoordinates.Keys.ToArray()[0]}-{TSpawnCoordinates.Keys.ToArray()[TSpawnCoordinates.Keys.Last()]}" +
				$"CT: {CTSpawnCoordinates.Keys.ToArray()[0]}-{CTSpawnCoordinates.Keys.ToArray()[CTSpawnCoordinates.Keys.Last()]}");
			return;
		}
		pawn.Teleport(vector);
	}

	private static bool CheckCommandArgCount(CCSPlayerController? player, CommandInfo command)
	{
		if (command.ArgCount != 2)
		{
			player?.PrintToChat("Too much arguments specified. Usage: '.spawn <number>'");
			return false;
		}
		return true;
	}

	private static int GetSpawnInserted(CCSPlayerController? player, CommandInfo command)
	{
		var spawnFromCommand = command.GetArg(1);
		if (!int.TryParse(spawnFromCommand, out int spawnPosition))
		{
			player?.PrintToChat("A number was not provided. Usage: '.spawn <number>'");
			return 0;
		}
		return spawnPosition;
	}

	private static Vector? GetSpawnCoordinates(int selectedSpawn, Dictionary<int, Vector> spawns)
	{
		if (!spawns.TryGetValue(selectedSpawn, out var vector)) return null;
		return vector;
	}

	private Vector? GetSpawnVector(CsTeam team, int selectedSpawn)
	{
		Dictionary<int, Vector>? dictionary;

		if (team == CsTeam.Terrorist) dictionary = TSpawnCoordinates;
		else if (team == CsTeam.CounterTerrorist) dictionary = CTSpawnCoordinates;
		else return null;

		return GetSpawnCoordinates(selectedSpawn, dictionary);
	}
}
