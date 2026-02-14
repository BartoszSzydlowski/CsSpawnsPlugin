using CounterStrikeSharp.API.Modules.Utils;
using CSPracticePlugin.MapProvider.Common;

namespace CSPracticePlugin.Resolvers;

public interface IMapResolver
{
	IBaseSpawnsProvider? Resolve(string mapName);

	Vector? GetSpawn(int spawnNumber, Dictionary<int, Vector> spawns);
}