
using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Consts;

namespace CsSpawnsPlugin.MapProvider;
public class MirageSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Mirage;

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(1136.0f,   32.0f,  -144.0f) },
		{ 2, new Vector(1136.0f,  -64.0f,  -144.0f) },
		{ 3, new Vector(1136.0f, -160.0f,  -144.0f) },
		{ 4, new Vector(1136.0f, -256.0f,  -144.0f) },
		{ 5, new Vector(1216.0f, -307.0f,  -144.0f) },
		{ 6, new Vector(1216.0f, -211.0f,  -144.0f) },
		{ 7, new Vector(1216.0f, -115.0f,  -144.0f) },
		{ 8, new Vector(1216.0f,  -16.0f,  -144.0f) },
		{ 9, new Vector(1296.0f,   32.0f,  -144.0f) },
		{ 10, new Vector(1296.0f,  -64.0f,  -144.0f) },
		{ 11, new Vector(1296.0f, -160.0f,  -144.0f) },
		{ 12, new Vector(1296.0f, -256.0f,  -144.0f) },
		{ 13, new Vector(1296.0f, -352.0f,  -144.0f) },
		{ 14, new Vector(1376.0f,  -16.0f,  -144.0f) },
		{ 15, new Vector(1376.0f, -112.0f,  -144.0f) },
		{ 16, new Vector(1376.0f, -208.0f,  -144.0f) },
		{ 17, new Vector(1376.0f, -304.0f,  -144.0f) },
	};

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-1972.0f, -1988.0f, -264.0f) },
		{ 2, new Vector(-1976.0f, -1812.0f, -272.0f) },
		{ 3, new Vector(-1957.0f, -1898.0f, -262.0f) },
		{ 4, new Vector(-1902.0f, -1976.0f, -240.0f) },
		{ 5, new Vector(-1902.0f, -1816.0f, -240.0f) },
		{ 6, new Vector(-1830.0f, -1896.0f, -240.0f) },
		{ 7, new Vector(-1776.0f, -1976.0f, -240.0f) },
		{ 8, new Vector(-1776.0f, -1800.0f, -240.0f) },
		{ 9, new Vector(-1720.0f, -1896.0f, -240.0f) },
		{ 10, new Vector(-1656.0f, -1800.0f, -240.0f) },
		{ 11, new Vector(-1656.0f, -1976.0f, -240.0f) },
		{ 12, new Vector(-1632.0f, -2072.0f, -240.0f) },
		{ 13, new Vector(-1608.0f, -1888.0f, -240.0f) },
		{ 14, new Vector(-1598.0f, -1732.0f, -240.0f) },
		{ 15, new Vector(-1552.0f, -1968.0f, -240.0f) },
		{ 16, new Vector(-1552.0f, -1808.0f, -240.0f) },
	};
}
