using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;

public abstract class BaseSpawnsProvider : IBaseSpawnsProvider
{
    public abstract string MapName { get; }

    public abstract CsTeam Team { get; }

    public abstract Dictionary<int, Vector> SpawnCoordinates { get; }
}
