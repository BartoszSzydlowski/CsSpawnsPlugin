using CounterStrikeSharp.API.Modules.Utils;
using CSPracticePlugin.Consts;
using CSPracticePlugin.MapProvider.Common;

namespace CSPracticePlugin.MapProvider.Providers;

public class OverpassSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Overpass;

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-2190f, 817f, 540.03125f) },
		{ 2, new Vector(-2199f, 740f, 540.03125f) },
		{ 3, new Vector(-2275f, 842f, 540.03125f) },
		{ 4, new Vector(-2273f, 770f, 540.03125f) },
		{ 5, new Vector(-2343f, 797f, 540.03125f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-1510.397949f, -3053.881836f, 344.031189f) },
		{ 2, new Vector(-1499f, -3126f, 337.395813f) },
		{ 3, new Vector(-1463f, -3190f, 340.642853f) },
		{ 4, new Vector(-1448f, -3076f, 325.655426f) },
		{ 5, new Vector(-1422.387085f, -3129.729248f, 328.918091f) },
		{ 6, new Vector(-1395f, -3190f, 332.733887f) },
		{ 7, new Vector(-1391f, -3262f, 340.631561f) },
		{ 8, new Vector(-1363f, -3122f, 321.113556f) },
		{ 9, new Vector(-1331f, -3190f, 325.290894f) },
		{ 10, new Vector(-1327f, -3262f, 333.188385f) },
		{ 11, new Vector(-1271f, -3262f, 326.676392f) },
	};
}