using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public class SpawnsPluginMock : SpawnsPlugin
{
    public string MapName { get; set; }

    private readonly IMapResolver mapResolver;
    private readonly IBaseSpawnsProvider baseSpawnsProvider = new MirageSpawnsProvider();

    public SpawnsPluginMock()
    {
        baseSpawnsProvider = new MirageSpawnsProvider();
        mapResolver = new MapResolver([baseSpawnsProvider]);
        SetDependencies(mapResolver, baseSpawnsProvider);
        MapName = "de_mirage";
    }

    public override void Load(bool hotReload)
    {
        var spawns = mapResolver.Resolve(MapName);

        Console.WriteLine($"Mock Load: resolved provider for '{spawns.MapName}' with {spawns.TSpawnCoordinates.Count} T spawns.");
    }

    public void LoadMock(bool hotReload)
    {
        if (baseSpawnsProvider != null)
            MapName = baseSpawnsProvider.MapName;
        Console.WriteLine("Plugin mock loaded successfully!");
    }
}
