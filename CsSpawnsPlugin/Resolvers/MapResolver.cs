using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Resolvers;
public class MapResolver(IEnumerable<IBaseSpawnsProvider> spawnsProviders) : IMapResolver
{
    private readonly Dictionary<(string, CsTeam), IBaseSpawnsProvider> spawnsProvdersDic
        = spawnsProviders.ToDictionary(x => (x.MapName, x.Team));

    private readonly IEnumerable<IBaseSpawnsProvider> xd = spawnsProviders;
    //public IBaseSpawnsProvider Resolve(string mapName, CsTeam team)
    //{
    //    return spawnsProvdersDic[(mapName, team)];
    //}

    public Vector? GetSpawn(string mapName, CsTeam team, int spawnNumber)
    {
        var spawns = spawnsProvdersDic[(mapName, team)];

        if (!spawns.SpawnCoordinates.TryGetValue(spawnNumber, out Vector? selectedSpawn))
            return null;

        return selectedSpawn;
    }
}