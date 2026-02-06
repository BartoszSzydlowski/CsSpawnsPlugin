
using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;
public class MirageSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => "de_mirage";

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(1216.00f, -115.00f, -160.95f) },
		{ 2, new Vector(1216.00f, -211.00f, -158.60f) },
		{ 3, new Vector(1136.00f, 32.000f, -158.78f) },
		{ 4, new Vector(1136.00f, -64.00f, -158.69f) },
		{ 5, new Vector(1136.00f, -256.00f, -158.83f) },
		{ 6, new Vector(1296.00f, 32.000f, -161.96f) },
		{ 7, new Vector(1216.00f, -307.04f, -158.81f) },
		{ 8, new Vector(1136.00f, -160.00f, -158.66f) },
		{ 9, new Vector(1296.00f, -352.00f, -161.96f) },
		{ 10, new Vector(1216.00f, -16.00f, -160.95f) },
	};

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-1776.00f, -1976.00f, -260.06f) },
		{ 2, new Vector(-1656.00f, -1976.00f, -261.90f) },
		{ 3, new Vector(-1720.00f, -1896.00f, -262.12f) },
		{ 4, new Vector(-1656.00f, -1800.00f, -261.80f) },
		{ 5, new Vector(-1776.00f, -1800.00f, -260.18f) },
	};
}
