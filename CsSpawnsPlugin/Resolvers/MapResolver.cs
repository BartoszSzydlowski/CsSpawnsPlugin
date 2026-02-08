using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Resolvers;
public class MapResolver(IEnumerable<IBaseSpawnsProvider> spawnsProviders) : IMapResolver
{
	private readonly Dictionary<string, IBaseSpawnsProvider> spawnsProvdersDic
		= spawnsProviders.ToDictionary(x => x.MapName);

	public Vector? GetSpawn(int spawnNumber, Dictionary<int, Vector> spawns) =>
		!spawns.TryGetValue(spawnNumber, out var selectedSpawn) ? null : selectedSpawn;

	public IBaseSpawnsProvider? Resolve(string mapName) =>
		!spawnsProvdersDic.TryGetValue(mapName, out var mapProvider) ? null : mapProvider;
}