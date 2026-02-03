using System.Numerics;

namespace CsSpawnsPlugin.MapProvider;
public interface IBaseMapProvider
{
    public string MapName { get; set; }

    public Dictionary<int, Vector3> SpawnCoordinates { get; set; }
}
