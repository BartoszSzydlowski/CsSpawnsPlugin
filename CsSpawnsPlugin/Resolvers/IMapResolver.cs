using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Resolvers;
public interface IMapResolver
{
    IBaseSpawnsProvider Resolve(string mapName);
}
