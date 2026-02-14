using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;
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
	public override string ModuleVersion => "0.0.25-beta";

	public override void Load(bool hotReload)
	{
		RegisterListener<OnMapStart>(OnMapStart);
		//RegisterListener<OnMapEnd>(OnMapEnd);
		RegisterEventHandler<EventPlayerSpawn>(OnPlayerSpawned);
		RegisterEventHandler<EventPlayerChat>(TeleportToSpawnCommand);
	}

	private HookResult TeleportToSpawnCommand(EventPlayerChat @event, GameEventInfo info)
	{
		var player = Utilities.GetPlayerFromUserid(@event.Userid);
		if (player?.IsValid != true)
			return HookResult.Continue;

		string message = @event.Text?.Trim() ?? "";

		if (!message.StartsWith(".spawn", StringComparison.OrdinalIgnoreCase))
			return HookResult.Continue;
		spawnCommandHandler.Handle(player, message, Logger);
		return HookResult.Handled;
	}

	private HookResult TeleportToTSpawnCommand(EventPlayerChat @event, GameEventInfo info)
	{
		var player = Utilities.GetPlayerFromUserid(@event.Userid);
		if (player?.IsValid != true)
			return HookResult.Continue;

		string message = @event.Text?.Trim() ?? "";

		if (!message.StartsWith(".tspawn", StringComparison.OrdinalIgnoreCase))
			return HookResult.Continue;
		spawnCommandHandler.Handle(player, message, Logger);
		return HookResult.Handled;
	}

	private HookResult TeleportToCTSpawnCommand(EventPlayerChat @event, GameEventInfo info)
	{
		var player = Utilities.GetPlayerFromUserid(@event.Userid);
		if (player?.IsValid != true)
			return HookResult.Continue;

		string message = @event.Text?.Trim() ?? "";

		if (!message.StartsWith(".ctspawn", StringComparison.OrdinalIgnoreCase))
			return HookResult.Continue;
		spawnCommandHandler.Handle(player, message, Logger);
		return HookResult.Handled;
	}

	private HookResult OnPlayerSpawned(EventPlayerSpawn @event, GameEventInfo info) =>
		(@event.Userid?.IsValid != true) ? HookResult.Continue : HookResult.Continue;

	private void OnMapStart(string mapName)
	{
		InitMapSpawns(mapName);
		Logger.LogInformation("Started map {mapName}", string.IsNullOrWhiteSpace(mapName) ? "map name not init" : mapName);
	}

	private void InitMapSpawns(string mapName)
	{
		var mapSpawns = mapResolver.Resolve(mapName);
		if (mapSpawns == null) return;

		spawnCommandHandler.TSpawnCoordinates = mapSpawns.TSpawnCoordinates;
		spawnCommandHandler.CTSpawnCoordinates = mapSpawns.CTSpawnCoordinates;
		spawnCommandHandler.MapName = mapName;
	}
}
