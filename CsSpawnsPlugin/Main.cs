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

    public string MapName { get; set; } = string.Empty;

    public override void Load(bool hotReload)
    {
        MapName = Server.MapName;
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

        var pawn = player.PlayerPawn.Value;
        if (pawn == null)
            return;

        var mapSpawns = mapResolver.Resolve(MapName);
    }
}
