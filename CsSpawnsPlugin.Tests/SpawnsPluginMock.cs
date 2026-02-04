using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public class SpawnsPluginMock : SpawnsPlugin
{
    public SpawnsPluginMock()
    {
        MapName = "";
    }

    public SpawnsPluginMock(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
    {
        SetDependencies(mapResolver, baseSpawnsProvider);
    }

    public override void Load(bool hotReload)
    {
        MapName = "de_mirage";

        var spawns = MapResolver!.Resolve(MapName);
    }

    public void LoadMock(bool hotReload)
    {
        MapName = "de_mirage";
        Console.WriteLine("Plugin loaded successfully!");
    }
}
