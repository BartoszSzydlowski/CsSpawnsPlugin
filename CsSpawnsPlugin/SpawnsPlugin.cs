using Autofac;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;
using CsSpawnsPlugin.Services;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin;

public class SpawnsPlugin : BasePlugin
{
    public override string ModuleName => "Main";

    public override string ModuleVersion => "1.0";

    private IContainer? container;
    private ISpawnsService? spawnsService;
    private IMapResolver? mapResolver;
    private IBaseSpawnsProvider? baseSpawnsProvider;

    public void SetDependencies(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
    {
        spawnsService = new SpawnsService(mapResolver, baseSpawnsProvider);
    }

    public override void Load(bool hotReload)
    {
        var builder = new ContainerBuilder();
        SetDependencies(mapResolver!, baseSpawnsProvider!);
        container = builder.Build();

        if (spawnsService == null)
            throw new InvalidOperationException("SpawnsPlugin dependencies are not initialized. Call SetDependencies(...) before Load().");


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

        var mapSpawns = spawnsService!.ResolveMap();
    }
}
