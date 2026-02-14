using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;
using CSPracticePlugin.Handlers;
using CSPracticePlugin.Resolvers;
using Microsoft.Extensions.Logging;
using static CounterStrikeSharp.API.Core.Listeners;

namespace CSPracticePlugin;

public class MainPlugin(
	IMapResolver mapResolver,
	ISpawnCommandHandler spawnCommandHandler) : BasePlugin
{
	public override string ModuleName => "CSPracticePlugin";
	public override string ModuleVersion => "0.0.28-beta";

	private string _mapName = string.Empty;

	public override void Load(bool hotReload)
	{
		RegisterListener<OnMapStart>(OnMapStart);
		RegisterEventHandler<EventPlayerSpawn>(OnPlayerSpawned);
		RegisterEventHandler<EventPlayerChat>(TeleportToSpawnCommand);
		RegisterEventHandler<EventPlayerTeam>(OnPlayerTeamChange);
	}

	private HookResult OnPlayerTeamChange(EventPlayerTeam @event, GameEventInfo info)
	{
		_mapName = Server.MapName;
		return HookResult.Handled;
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

	private HookResult OnPlayerSpawned(EventPlayerSpawn @event, GameEventInfo info)
	{
		_mapName = Server.MapName;
		if (@event.Userid?.IsValid != true)
		{
			return HookResult.Continue;
		}
		else
		{
			return HookResult.Continue;
		}
	}

	private void OnMapStart(string mapName)
	{
		_mapName = mapName;
		InitMapSpawns(_mapName);
		Logger.LogInformation("Started map {mapName}", string.IsNullOrWhiteSpace(mapName) ? "map name not init" : mapName);
	}

	private void InitMapSpawns(string mapName)
	{
		var mapSpawns = mapResolver.Resolve(mapName);
		if (mapSpawns == null) return;

		spawnCommandHandler.TSpawnCoordinates = mapSpawns.TSpawnCoordinates;
		spawnCommandHandler.CTSpawnCoordinates = mapSpawns.CTSpawnCoordinates;
	}
}