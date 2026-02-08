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

	public override string ModuleVersion => "0.0.10-beta";

	private string mapName = string.Empty;

	public override void Load(bool hotReload)
	{
		try
		{
			RegisterListener<OnMapStart>(OnMapStart);
			RegisterListener<OnMapEnd>(OnMapEnd);
			//RegisterListener<OnClientConnected>(OnClientConnected);
			//RegisterEventHandler<EventPlayerConnect>(EventPlayerConnectMethod);
			//RegisterEventHandler<EventPlayerChat>(CommandSpawn)
			RegisterEventHandler<EventPlayerSpawn>(OnPlayerSpawned);
			InitMapSpawns(mapName);
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

	//private HookResult EventPlayerConnectMethod(EventPlayerConnect @event, GameEventInfo info)
	//{
	//	Logger.LogInformation("Player {Name} has connected! (outside if)", @event.Userid?.PlayerName ?? "dalej null");
	//	if (@event.Userid?.IsValid == true)
	//	{
	//		//player = @event.Userid;
	//		Logger.LogInformation("Player {Name} has connected!", @event.Userid);
	//	}
	//	return HookResult.Continue;
	//}

	private void OnMapEnd()
	{
		Logger.LogInformation("Map {mapName} ended, plugin unloaded", mapName);
		mapName = string.Empty;
	}

	private void OnMapStart(string mapName)
	{
		this.mapName = mapName;
		Logger.LogInformation("Map started: {mapName}", mapName);
	}

	//[GameEventHandler]
	//public HookResult OnPlayerConnect(EventPlayerConnect @event)
	//{
	//	if (@event.Userid?.IsValid == true)
	//	{
	//		player = @event.Userid;
	//		Logger.LogInformation("Player {Name} has connected!", player);
	//	}
	//	return HookResult.Continue;
	//}

	//public void OnClientConnected(int playerSlot)
	//{
	//	Logger.LogInformation("Player {Name} has connected!", player);
	//}

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
