using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Services;
public interface ISpawnsService
{
    IBaseSpawnsProvider ResolveMap(string? mapName = null);
    (bool ok, string message) ValidateSpawnArgs(string[] args);
}
