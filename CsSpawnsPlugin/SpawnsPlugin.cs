using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.Logging;
using static CounterStrikeSharp.API.Core.Listeners;

namespace CsSpawnsPlugin;

public class SpawnsPlugin(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider) : BasePlugin
{
    public override string ModuleName => "Main";

    public override string ModuleVersion => "1.0";

    private string mapName = string.Empty;

    //private readonly IMapResolver? mapResolver;
    //private readonly IBaseSpawnsProvider? baseSpawnsProvider;

    public override void Load(bool hotReload)
    {
        RegisterListener<OnMapStart>(OnMapStart);
        RegisterListener<OnMapEnd>(OnMapEnd);
        mapName = Server.MapName;
        AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
        Logger.LogInformation("Plugin loaded successfully!");
    }

    public override void OnAllPluginsLoaded(bool hotReload)
    {

    }

    private void OnMapEnd()
    {
        mapName = Server.MapName;
        Logger.LogInformation("Map {mapName} ended, plugin unloaded", mapName);
    }

    private void OnMapStart(string mapName)
    {
        Load(true);
        Logger.LogInformation("Map started: {mapName}", mapName);
    }

    [GameEventHandler]
    public HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
    {
        Logger.LogInformation("Player {Name} has connected!", @event.Userid?.PlayerName);
        return HookResult.Continue;
    }

    private void CommandSpawn(CCSPlayerController? player, CommandInfo command)
    {
        if (player?.IsValid != true)
            return;

        if (!CheckCommandArgCount(player, command))
            return;

        var pawn = player.PlayerPawn.Value;
        if (pawn == null)
            return;

        var team = player.Team;
        var selectedSpawn = GetSpawnInserted(player, command);

        var spawn = mapResolver?.GetSpawn(mapName, team, selectedSpawn);

        if (spawn == null)
        {
            Logger.LogInformation("Invalid spawn number {spawn}", spawn);
            return;
        }
        pawn.Teleport(spawn);
    }

    private int GetSpawnInserted(CCSPlayerController? player, CommandInfo command)
    {
        var spawnFromCommand = command.GetArg(1);

        if (!int.TryParse(spawnFromCommand, out int spawnPosition))
        {
            player?.PrintToChat("Usage: .spawn <number>");
            return 0;
        }

        return spawnPosition;
    }

    private bool CheckCommandArgCount(CCSPlayerController? player, CommandInfo command)
    {
        if (command.ArgCount != 2)
        {
            player?.PrintToChat("Usage: .spawn <number>");
            return false;
        }
        return true;
    }
}
