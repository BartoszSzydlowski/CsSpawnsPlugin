using Autofac;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public class SpawnsPluginMock
{
    public string ModuleName => "Main";

    public string ModuleVersion => "1.0";

    private IContainer? container;
    private readonly IMapResolver mapResolver;
    private readonly IBaseSpawnsProvider? baseSpawnsProvider;

    public SpawnsPluginMock(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
    {
        this.mapResolver = mapResolver;
        this.baseSpawnsProvider = baseSpawnsProvider;
        Load();
    }

    public void Load()
    {
        var builder = new ContainerBuilder();
        container = builder.Build();
        Console.WriteLine("Plugin loaded successfully!");
        CommandSpawn();
    }

    private void CommandSpawn()
    {
        var mapSpawns = mapResolver!.Resolve("de_mirage");
        const string args = ".spawn 1";
        var selectedSpawn = Convert.ToInt32(args.Split(' ')[1]);
        var spawn = mapSpawns.TSpawnCoordinates[selectedSpawn];
        Console.WriteLine(spawn);
    }
}
