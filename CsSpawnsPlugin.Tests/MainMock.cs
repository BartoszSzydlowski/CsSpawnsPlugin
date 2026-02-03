using CounterStrikeSharp.API;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public class MainMock(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
    : Main(mapResolver, baseSpawnsProvider)
{
    public override void Load(bool hotReload)
    {
        MapName = "de_mirage";

        var spawns = mapResolver.Resolve(MapName);

        //base.Load(hotReload);
    }

    public void LoadMock(bool hotReload)
    {
        MapName = Server.MapName;
        Console.WriteLine("Plugin loaded successfully!");
    }
}
