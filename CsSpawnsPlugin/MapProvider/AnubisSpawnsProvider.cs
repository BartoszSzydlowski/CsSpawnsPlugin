using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;
public class AnubisSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => throw new NotImplementedException();

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-360f, 2120f, 80.056595f) },
		{ 2, new Vector(-400f, 2192f, 82.439697f) },
		{ 3, new Vector(-476f, 2216f, 88.223145f) },
		{ 4, new Vector(-560f, 2192f, 82.439697f) },
		{ 5, new Vector(-608f, 2120f, 80.056595f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-128.004028f, -1632f, 55.867554f) },
		{ 2, new Vector(-144f, -1568f, 52.03125f) },
		{ 3, new Vector(-154f, -1503.079956f, 52.03125f) },
		{ 4, new Vector(-192f, -1608f, 52.03125f) },
		{ 5, new Vector(-234f, -1503.079956f, 52.03125f) },
		{ 6, new Vector(-264f, -1560f, 52.03125f) },
		{ 7, new Vector(-304f, -1608f, 52.03125f) },
		{ 8, new Vector(-328f, -1528f, 52.03125f) },
		{ 9, new Vector(-384f, -1552f, 52.03125f) },
		{ 10, new Vector(-416f, -1608f, 64.814697f) },
		{ 11, new Vector(-416f, -1696f, 66.03125f) },
	};
}
