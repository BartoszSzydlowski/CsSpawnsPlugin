using Autofac;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin;

public class SpawnsPlugin : BasePlugin
{
    public override string ModuleName => "Main";

    public override string ModuleVersion => "1.0";

    private IContainer? container;
    private readonly IMapResolver? mapResolver;
    private readonly IBaseSpawnsProvider? baseSpawnsProvider;

    public override void Load(bool hotReload)
    {
        var builder = new ContainerBuilder();
        container = builder.Build();

        //MapName = Server.MapName;
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

        var mapSpawns = mapResolver!.Resolve(Server.MapName);

        var team = player.Team;

        var selectedSpawn = Convert.ToInt32(command.GetArg(1));

        Vector? spawn;

        if (team == CsTeam.Terrorist)
            spawn = mapSpawns.TSpawnCoordinates[selectedSpawn];
        else if (team == CsTeam.CounterTerrorist)
            spawn = mapSpawns.CTSpawnCoordinates[selectedSpawn];
        else
            return;

        pawn.Teleport(spawn);
    }
}
