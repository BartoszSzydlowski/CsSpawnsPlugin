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

	private CCSPlayerController player = null!;

	public override void Load(bool hotReload)
	{
		try
		{
			RegisterListener<OnMapStart>(OnMapStart);
			RegisterListener<OnMapEnd>(OnMapEnd);
			RegisterListener<OnClientConnected>(OnClientConnected);
			RegisterEventHandler<EventPlayerConnect>(EventPlayerConnectMethod);
			InitMapSpawns(mapName);
			AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
			Logger.LogInformation("Plugin loaded successfully!");
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "An exception occurred: {Message}", ex.Message);
		}
	}

	private HookResult EventPlayerConnectMethod(EventPlayerConnect @event, GameEventInfo info)
	{
		if (@event.Userid?.IsValid == true)
		{
			player = @event.Userid;
			Logger.LogInformation("Player {Name} has connected!", player);
		}
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

	public void OnClientConnected(int playerSlot)
	{
		Logger.LogInformation("Player {Name} has connected!", player);
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
