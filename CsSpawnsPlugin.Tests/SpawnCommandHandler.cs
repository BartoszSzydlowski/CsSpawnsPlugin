using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;
public class SpawnCommandHandler(IMapResolver mapResolver)
{
    public Vector Handle(string mapName, string args)
    {
        var mapSpawns = mapResolver.Resolve(mapName);
        var selectedSpawn = int.Parse(args.Split(' ')[1]);
        return mapSpawns.TSpawnCoordinates[selectedSpawn];
    }
}
