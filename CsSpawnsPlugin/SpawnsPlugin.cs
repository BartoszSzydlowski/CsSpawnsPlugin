using Autofac;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin;

public class SpawnsPlugin : BasePlugin
{
    public override string ModuleName => "Main";

    public override string ModuleVersion => "1.0";

    public string MapName { get; set; } = string.Empty;

    private IContainer? container;

    protected IMapResolver? MapResolver;

    protected IBaseSpawnsProvider? BaseSpawnsProvider;

    public void SetDependencies(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
    {
        MapResolver = mapResolver ?? throw new ArgumentNullException(nameof(mapResolver));
        BaseSpawnsProvider = baseSpawnsProvider ?? throw new ArgumentNullException(nameof(baseSpawnsProvider));
    }

    public override void Load(bool hotReload)
    {
        if (MapResolver == null || BaseSpawnsProvider == null)
            throw new InvalidOperationException("SpawnsPlugin dependencies are not initialized. Call SetDependencies(...) before Load().");

        var builder = new ContainerBuilder();
        container = builder.Build();

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

        var mapSpawns = MapResolver!.Resolve(MapName);
    }
}
