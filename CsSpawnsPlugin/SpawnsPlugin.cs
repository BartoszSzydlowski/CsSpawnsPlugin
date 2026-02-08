using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CsSpawnsPlugin.Handlers;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.Logging;
using static CounterStrikeSharp.API.Core.Listeners;

namespace CsSpawnsPlugin;

public class SpawnsPlugin(
	IMapResolver mapResolver,
	ISpawnCommandHandler spawnCommandHandler) : BasePlugin
{
	public override string ModuleName => "SpawnsPlugin";
	public override string ModuleVersion => "0.0.15-beta";

	private string mapName = string.Empty;

	public override void Load(bool hotReload)
	{
		try
		{
			RegisterListener<OnMapStart>(OnMapStart);
			RegisterListener<OnMapEnd>(OnMapEnd);
			RegisterEventHandler<EventPlayerSpawn>(OnPlayerSpawned);
			AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
			Logger.LogInformation("Plugin loaded successfully!");
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "An exception occurred: {Message}", ex.Message);
		}
	}

	private HookResult OnPlayerSpawned(EventPlayerSpawn @event, GameEventInfo info)
	{
		var player = @event.Userid;

		if (player?.IsValid != true)
			return HookResult.Continue;

		Logger.LogInformation("Player {Name} has spawned", player.PlayerName);
		return HookResult.Continue;
	}

	private void OnMapEnd()
	{
		Logger.LogInformation("Map {mapName} ended, plugin unloaded", mapName);
		mapName = string.Empty;
	}

	private void OnMapStart(string mapName)
	{
		this.mapName = mapName;
		InitMapSpawns(this.mapName);
		Logger.LogInformation("Map started: {mapName}", mapName);
	}

	private void CommandSpawn(CCSPlayerController? player, CommandInfo command)
	{
		if (player?.IsValid != true)
		{
			Logger.LogWarning("CommandSpawn called with null player");
			return;
		}

		Logger.LogInformation("{playerName}", player?.PlayerName);
		spawnCommandHandler.Handle(player, command, Logger);
	}

	private void InitMapSpawns(string mapName)
	{
		var mapSpawns = mapResolver.Resolve(mapName);
		if (mapSpawns == null)
		{
			Logger.LogInformation("Map {mapName} not found", mapName);
			return;
		}

		spawnCommandHandler.TSpawnCoordinates = mapSpawns.TSpawnCoordinates;
		spawnCommandHandler.CTSpawnCoordinates = mapSpawns.CTSpawnCoordinates;
	}
}
