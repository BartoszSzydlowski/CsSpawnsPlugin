using System.Numerics;

namespace CsSpawnsPlugin.MapProvider;

public abstract class BaseMapProvider : IMapProvider
{
    public abstract string MapName { get; set; }
    public abstract Dictionary<int, Vector3> SpawnCoordinates { get; set; }
}
