
using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Consts;

namespace CsSpawnsPlugin.MapProvider;
public class MirageSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Mirage;

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(1136f, -256f, -144f) },
		{ 2, new Vector(1136f, -160f, -144f) },
		{ 3, new Vector(1136f, -64f, -144f) },
		{ 4, new Vector(1136f, 32f, -144f) },
		{ 5, new Vector(1216f, -307f, -144f) },
		{ 6, new Vector(1216f, -211f, -144f) },
		{ 7, new Vector(1216f, -115f, -144f) },
		{ 8, new Vector(1216f, -16f, -144f) },
		{ 9, new Vector(1296f, -352f, -144f) },
		{ 10, new Vector(1296f, 32f, -144f) },
	};

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-1776f, -1976f, -240f) },
		{ 2, new Vector(-1776f, -1800f, -240f) },
		{ 3, new Vector(-1720f, -1896f, -240f) },
		{ 4, new Vector(-1656f, -1800f, -240f) },
		{ 5, new Vector(-1656f, -1976f, -240f) },
	};
}
