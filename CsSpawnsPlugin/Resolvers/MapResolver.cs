using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Resolvers;
public class MapResolver(IEnumerable<IBaseSpawnsProvider> spawnsProviders) : IMapResolver
{
	private readonly Dictionary<string, IBaseSpawnsProvider> spawnsProvdersDic
		= spawnsProviders.ToDictionary(x => x.MapName);

	public Vector? GetSpawn(int spawnNumber, Dictionary<int, Vector> spawns)
	{
		if (!spawns.TryGetValue(spawnNumber, out Vector? selectedSpawn))
			return null;

		return selectedSpawn;
	}

	public IBaseSpawnsProvider? Resolve(string mapName)
	{
		if (!spawnsProvdersDic.TryGetValue(mapName, out var mapProvider))
			return null;

		return mapProvider;
	}
}