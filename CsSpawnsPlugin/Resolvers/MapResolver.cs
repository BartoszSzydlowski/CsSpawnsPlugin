using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Resolvers;
public class MapResolver(IEnumerable<IBaseSpawnsProvider> spawnsProviders) : IMapResolver
{
    private readonly IDictionary<string, IBaseSpawnsProvider> spawnsProvdersDic = spawnsProviders.ToDictionary(x => x.MapName);

    public IBaseSpawnsProvider Resolve(string mapName)
    {
        return spawnsProvdersDic[mapName];
    }
}
