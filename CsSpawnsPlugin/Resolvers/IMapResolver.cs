using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Resolvers;
public interface IMapResolver
{
	IBaseSpawnsProvider? Resolve(string mapName);
	Vector? GetSpawn(int spawnNumber, Dictionary<int, Vector> spawns);
}
