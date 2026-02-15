using CounterStrikeSharp.API.Modules.Utils;
using CSPracticePlugin.MapProvider.Common;

namespace CSPracticePlugin.Resolvers;

public class MapResolver(IEnumerable<IBaseSpawnsProvider> spawnsProviders) : IMapResolver
{
	private readonly Dictionary<string, IBaseSpawnsProvider> _spawnsProvdersDic
		= spawnsProviders.ToDictionary(x => x.MapName);

	public Vector? GetSpawn(int spawnNumber, Dictionary<int, Vector> spawns) =>
		!spawns.TryGetValue(spawnNumber, out var selectedSpawn) ? null : selectedSpawn;

	public IBaseSpawnsProvider? Resolve(string mapName) =>
		!_spawnsProvdersDic.TryGetValue(mapName, out var mapProvider) ? null : mapProvider;
}