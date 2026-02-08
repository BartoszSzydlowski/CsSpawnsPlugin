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
	public override string ModuleVersion => "0.0.16-beta";

	private string mapName = string.Empty;

	public override void Load(bool hotReload)
	{
		RegisterListener<OnMapStart>(OnMapStart);
		RegisterListener<OnMapEnd>(OnMapEnd);
		RegisterEventHandler<EventPlayerSpawn>(OnPlayerSpawned);
		AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
		Logger.LogInformation("Plugin loaded successfully!");
	}

	private HookResult OnPlayerSpawned(EventPlayerSpawn @event, GameEventInfo info)
	{
		var player = @event.Userid;

		if (player?.IsValid != true)
			return HookResult.Continue;

		return HookResult.Continue;
	}

	private void OnMapEnd()
	{
		mapName = string.Empty;
	}

	private void OnMapStart(string mapName)
	{
		this.mapName = mapName;
		InitMapSpawns(this.mapName);
	}

	private void CommandSpawn(CCSPlayerController? player, CommandInfo command)
	{
		if (player?.IsValid != true) return;

		spawnCommandHandler.Handle(player, command, Logger);
	}

	private void InitMapSpawns(string mapName)
	{
		var mapSpawns = mapResolver.Resolve(mapName);
		if (mapSpawns == null) return;

		spawnCommandHandler.TSpawnCoordinates = mapSpawns.TSpawnCoordinates;
		spawnCommandHandler.CTSpawnCoordinates = mapSpawns.CTSpawnCoordinates;
		spawnCommandHandler.MapName = this.mapName;
	}
}
