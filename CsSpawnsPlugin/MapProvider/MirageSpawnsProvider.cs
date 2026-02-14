
using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Consts;

namespace CsSpawnsPlugin.MapProvider;
public class MirageSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Mirage;

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(1136.0f, -256.0f, -144.0f) },
		{ 2, new Vector(1136.0f, -160.0f, -144.0f) },
		{ 3, new Vector(1136.0f, -64.0f, -144.0f) },
		{ 4, new Vector(1136.0f, 32.0f, -144.0f) },
		{ 5, new Vector(1216.0f, -307.0f, -144.0f) },
		{ 6, new Vector(1216.0f, -211.0f, -144.0f) },
		{ 7, new Vector(1216.0f, -115.0f, -144.0f) },
		{ 8, new Vector(1216.0f, -16.0f, -144.0f) },
		{ 9, new Vector(1296.0f, -352.0f, -144.0f) },
		{ 10, new Vector(1296.0f, 32.0f, -144.0f) },
	};

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-1776.0f, -1976.0f, -240.0f) },
		{ 2, new Vector(-1776.0f, -1800.0f, -240.0f) },
		{ 3, new Vector(-1720.0f, -1896.0f, -240.0f) },
		{ 4, new Vector(-1656.0f, -1800.0f, -240.0f) },
		{ 5, new Vector(-1656.0f, -1976.0f, -240.0f) },
	};
}
