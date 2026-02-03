using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin;

public class Main(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider) : BasePlugin
{
    public override string ModuleName => "Main";

    public override string ModuleVersion => "1.0";

    private string mapName = string.Empty;

    public override void Load(bool hotReload)
    {
        mapName = Server.MapName;
        AddCommand(".spawn", "Teleport to a spawn", CommandSpawn);
        Logger.LogInformation("Plugin loaded successfully!");
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

        if (command.ArgCount < 2)
        {
            player.PrintToChat("Usage: .spawn <number>");
            return;
        }

        //if (!int.TryParse(command.GetArg(1), out int spawnNumber))
        //{
        //    player.PrintToChat("Invalid spawn number.");
        //    return;
        //}

        //if (!Spawns.TryGetValue(spawnNumber, out var position))
        //{
        //    player.PrintToChat($"Spawn {spawnNumber} does not exist.");
        //    return;
        //}

        var pawn = player.PlayerPawn.Value;
        if (pawn == null)
            return;

        var mapSpawns = mapResolver.Resolve(mapName);

        var side = player.;

        pawn.Teleport(
            position,
            pawn.AbsRotation,
            Vector3.Zero
        );

        player.PrintToChat($"Teleported to spawn {spawnNumber}.");
    }
}
