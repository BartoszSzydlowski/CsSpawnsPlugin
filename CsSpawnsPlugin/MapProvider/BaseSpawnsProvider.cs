using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;

public abstract class BaseSpawnsProvider : IBaseSpawnsProvider
{
    public abstract string MapName { get; }

    public abstract Dictionary<int, Vector> TSpawnCoordinates { get; }

    public abstract Dictionary<int, Vector> CTSpawnCoordinates { get; }
}
