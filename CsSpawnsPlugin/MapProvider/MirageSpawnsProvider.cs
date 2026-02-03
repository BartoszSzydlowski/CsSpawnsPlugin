using System.Numerics;

namespace CsSpawnsPlugin.MapProvider;
internal class MirageSpawnsProvider : BaseSpawnsProvider
{
    public override string MapName => "de_mirage";

    public override Dictionary<int, Vector3> TSpawnCoordinates => new()
    {
        { 1, new Vector3(1216.00f, -115.00f, -160.95f) },
        { 2, new Vector3(1216.00f, -211.00f, -158.60f) },
        { 3, new Vector3(1136.00f, 32.000f, -158.78f) },
        { 4, new Vector3(1136.00f, -64.00f, -158.69f) },
        { 5, new Vector3(1136.00f, -256.00f, -158.83f) },
        { 6, new Vector3(1296.00f, 32.000f, -161.96f) },
        { 7, new Vector3(1216.00f, -307.04f, -158.81f) },
        { 8, new Vector3(1136.00f, -160.00f, -158.66f) },
        { 9, new Vector3(1296.00f, -352.00f, -161.96f) },
        { 10, new Vector3(1216.00f, -16.00f, -160.95f) },
    };

    public override Dictionary<int, Vector3> CTSpawnCoordinates => new()
    {
        { 1, new Vector3(1216.00f, -115.00f, -160.95f) },
        { 2, new Vector3(1216.00f, -211.00f, -158.60f) },
        { 3, new Vector3(1136.00f, 32.000f, -158.78f) },
        { 4, new Vector3(1136.00f, -64.00f, -158.69f) },
        { 5, new Vector3(1136.00f, -256.00f, -158.83f) },
    };
}
