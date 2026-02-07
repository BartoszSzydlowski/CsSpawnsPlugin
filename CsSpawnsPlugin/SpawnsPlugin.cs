using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
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

	public override string ModuleVersion => "1.0";

	private string mapName = string.Empty;

	public override void Load(bool hotReload)
	{
		try
		{
			RegisterListener<OnMapStart>((mapName) =>
			{
				this.mapName = mapName;
				Logger.LogInformation("Map started: {mapName}", mapName);
			});
			RegisterListener<OnMapEnd>(OnMapEnd);
			InitMapSpawns(mapName);
			AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
			Logger.LogInformation("Plugin loaded successfully!");
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message);
		}
	}

	private void OnMapEnd()
	{
		Logger.LogInformation("Map {mapName} ended, plugin unloaded", mapName);
		mapName = string.Empty;
	}

	[GameEventHandler]
	public HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
	{
		Logger.LogInformation("Player {Name} has connected!", @event.Userid?.PlayerName);
		return HookResult.Continue;
	}

	private void CommandSpawn(CCSPlayerController? player, CommandInfo command)
	{
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
