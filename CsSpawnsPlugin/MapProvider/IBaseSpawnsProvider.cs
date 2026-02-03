using System.Numerics;

namespace CsSpawnsPlugin.MapProvider;
public interface IBaseSpawnsProvider
{
    public string MapName { get; }

    public Dictionary<int, Vector3> TSpawnCoordinates { get; }

    public Dictionary<int, Vector3> CTSpawnCoordinates { get; }
}
