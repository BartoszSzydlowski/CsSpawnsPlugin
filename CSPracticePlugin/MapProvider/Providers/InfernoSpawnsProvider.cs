using CounterStrikeSharp.API.Modules.Utils;
using CSPracticePlugin.Consts;
using CSPracticePlugin.MapProvider.Common;

namespace CSPracticePlugin.MapProvider.Providers;

public class InfernoSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Inferno;

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(2292.060059f, 2027.689941f, 199.468185f) },
		{ 2, new Vector(2353f, 1977f, 199.129715f) },
		{ 3, new Vector(2397f, 2079f, 196.637909f) },
		{ 4, new Vector(2456.830078f, 2153.159912f, 196.063141f) },
		{ 5, new Vector(2472.349854f, 2005.969971f, 197.822189f) },
		{ 6, new Vector(2493f, 2090f, 196.27269f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-1520.060059f, 430.890991f, 0.03125f) },
		{ 2, new Vector(-1586.52002f, 440.790009f, 0.03125f) },
		{ 3, new Vector(-1657.22998f, 419.576996f, 0.03125f) },
		{ 4, new Vector(-1662.180054f, 288.761993f, 0.03125f) },
		{ 5, new Vector(-1675.619995f, 351.695007f, 0.03125f) },
	};
}