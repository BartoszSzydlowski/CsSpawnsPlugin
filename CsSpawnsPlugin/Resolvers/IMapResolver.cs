using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.Resolvers;
public interface IMapResolver
{
    //IBaseSpawnsProvider Resolve(string mapName, CsTeam team);

    Vector? GetSpawn(string mapName, CsTeam team, int spawnNumber);
}
