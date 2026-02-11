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
	public override string ModuleVersion => "0.0.19-beta";

	private string mapName = string.Empty;

	public override void Load(bool hotReload)
	{
		RegisterListener<OnMapStart>(OnMapStart);
		RegisterListener<OnMapEnd>(OnMapEnd);
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
		Server.PrintToConsole($"{ModuleName}, {ModuleVersion} loaded ");
		return HookResult.Handled;
	}

	private HookResult OnPlayerSpawned(EventPlayerSpawn @event, GameEventInfo info) =>
		(@event.Userid?.IsValid != true) ? HookResult.Continue : HookResult.Continue;

	private void OnMapEnd() => mapName = string.Empty;

	private void OnMapStart(string mapName)
	{
		var util1 = Utilities.FindAllEntitiesByDesignerName<CBaseEntity>("info_player_terrorist");
		var util2 = Utilities.FindAllEntitiesByDesignerName<CBaseEntity>("info_player_counterterrorist");
		var count = 0;
		foreach (var util in util1)
		{
			count++;
			Logger.LogInformation("TSpawn {count}: X - {X}, Y - {Y}, Z - {Z}", count, util.AbsOrigin?.X, util.AbsOrigin?.Y, util.AbsOrigin?.Z);
			Server.PrintToConsole($"TSpawn ${count}: X - ${util.AbsOrigin?.X}, Y - ${util.AbsOrigin?.Y}, Z - ${util.AbsOrigin?.Z}");
		}
		count = 0;
		foreach (var util in util2)
		{
			count++;
			Logger.LogInformation("CTSpawn {count}: X - {X}, Y - {Y}, Z - {Z}", count, util.AbsOrigin?.X, util.AbsOrigin?.Y, util.AbsOrigin?.Z);
			Server.PrintToConsole($"TSpawn ${count}: X - ${util.AbsOrigin?.X}, Y - ${util.AbsOrigin?.Y}, Z - ${util.AbsOrigin?.Z}");
		}

		this.mapName = mapName;
		InitMapSpawns(this.mapName);
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
