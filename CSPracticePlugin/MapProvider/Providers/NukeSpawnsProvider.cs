using CounterStrikeSharp.API.Modules.Utils;
using CSPracticePlugin.Consts;
using CSPracticePlugin.MapProvider.Common;

namespace CSPracticePlugin.MapProvider.Providers;

public class NukeSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Nuke;

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(2504f, -344f, -287.96875f) },
		{ 2, new Vector(2512f, -504f, -284.439514f) },
		{ 3, new Vector(2552f, -424f, -287.96875f) },
		{ 4, new Vector(2584f, -504f, -287.96875f) },
		{ 5, new Vector(2585f, -344f, -287.96875f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-1808f, -1025f, -351.96875f) },
		{ 2, new Vector(-1808f, -1089f, -351.96875f) },
		{ 3, new Vector(-1832f, -1160f, -351.96875f) },
		{ 4, new Vector(-1874f, -1076f, -351.96875f) },
		{ 5, new Vector(-1878f, -980f, -351.96875f) },
		{ 6, new Vector(-1929f, -1025f, -351.96875f) },
		{ 7, new Vector(-1947.01001f, -965.109985f, -351.96875f) },
		{ 8, new Vector(-1947.01001f, -1102.109985f, -351.96875f) },
	};
}