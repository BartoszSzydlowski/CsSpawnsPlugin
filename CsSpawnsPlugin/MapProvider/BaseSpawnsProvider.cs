using System.Numerics;

namespace CsSpawnsPlugin.MapProvider;

public abstract class BaseSpawnsProvider : IBaseSpawnsProvider
{
    public abstract string MapName { get; }

    public abstract Dictionary<int, Vector3> TSpawnCoordinates { get; }

    public abstract Dictionary<int, Vector3> CTSpawnCoordinates { get; }
}
