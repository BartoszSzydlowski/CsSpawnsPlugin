using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;
using CsSpawnsPlugin.Handlers;
using CsSpawnsPlugin.Resolvers;
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
		RegisterEventHandler<EventPlayerChat>(OnPlayerChat);
		AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
	}

	private HookResult OnPlayerChat(EventPlayerChat @event, GameEventInfo info)
	{
		var player = Utilities.GetPlayerFromUserid(@event.Userid);
		if (player == null || !player.IsValid)
			return HookResult.Continue;

		string message = @event.Text?.Trim() ?? "";

		// Example: ".spawn 2"
		if (!message.StartsWith(".spawn", StringComparison.OrdinalIgnoreCase))
			return HookResult.Continue;

		//var args = message.Split(' ', StringSplitOptions.RemoveEmptyEntries);

		//if (args.Length < 2)
		//{
		//	player.PrintToChat("Usage: .spawn <number>");
		//	return HookResult.Handled;
		//}

		//if (!int.TryParse(args[1], out int spawnId))
		//{
		//	player.PrintToChat("Invalid spawn number.");
		//	return HookResult.Handled;
		//}
		//HandleSpawn(player, spawnId);

		spawnCommandHandler.Handle(player, message, Logger);
		// Prevent the message from showing in chat (optional)
		return HookResult.Handled;
	}

	private HookResult OnPlayerSpawned(EventPlayerSpawn @event, GameEventInfo info) =>
		(@event.Userid?.IsValid != true) ? HookResult.Continue : HookResult.Continue;

	private void OnMapEnd() => mapName = string.Empty;

	private void OnMapStart(string mapName)
	{
		this.mapName = mapName;
		InitMapSpawns(this.mapName);
	}

	//private void CommandSpawn(CCSPlayerController? player, CommandInfo command)
	//{
	//	if (player?.IsValid != true) return;
	//	spawnCommandHandler.Handle(player, command, Logger);
	//}

	private void InitMapSpawns(string mapName)
	{
		var mapSpawns = mapResolver.Resolve(mapName);
		if (mapSpawns == null) return;

		spawnCommandHandler.TSpawnCoordinates = mapSpawns.TSpawnCoordinates;
		spawnCommandHandler.CTSpawnCoordinates = mapSpawns.CTSpawnCoordinates;
		spawnCommandHandler.MapName = mapName;
	}
}
