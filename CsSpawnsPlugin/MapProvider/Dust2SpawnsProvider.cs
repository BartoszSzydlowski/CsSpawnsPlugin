using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Consts;

namespace CsSpawnsPlugin.MapProvider;
public class Dust2SpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Dust2;

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(160.122742f, 2369.67627f, -56.599121f) },
		{ 2, new Vector(182.249908f, 2439.011719f, -57.388428f) },
		{ 3, new Vector(258.159393f, 2480.553711f, -58.393921f) },
		{ 4, new Vector(334.368744f, 2433.733643f, -56.988647f) },
		{ 5, new Vector(351.39212f, 2352.942383f, -57.179382f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-332f, -754f, 138.16922f) },
		{ 2, new Vector(-367f, -808f, 144.104218f) },
		{ 3, new Vector(-428f, -843f, 156.405899f) },
		{ 4, new Vector(-493f, -808f, 169.493423f) },
		{ 5, new Vector(-533f, -754f, 175.41806f) },
		{ 6, new Vector(-657.271362f, -755.879639f, 182.337753f) },
		{ 7, new Vector(-696.844604f, -806.623718f, 180.301468f) },
		{ 8, new Vector(-760.662964f, -836.174011f, 180.705933f) },
		{ 9, new Vector(-822.365173f, -795.64209f, 180.864716f) },
		{ 10, new Vector(-857.506531f, -738.361328f, 183.436768f) },
		{ 11, new Vector(-980f, -754f, 183.110443f) },
		{ 12, new Vector(-1015f, -808f, 179.732513f) },
		{ 13, new Vector(-1076f, -843f, 180.466232f) },
		{ 14, new Vector(-1141f, -808f, 180.029617f) },
		{ 15, new Vector(-1181f, -754f, 183.110443f) },
	};
}
