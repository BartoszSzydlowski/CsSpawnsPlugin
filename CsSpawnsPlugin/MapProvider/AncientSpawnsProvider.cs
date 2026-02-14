using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Consts;

namespace CsSpawnsPlugin.MapProvider;
public class AncientSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Ancient;

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-192.0f, 1696.0f, 88.793152f) },
		{ 2, new Vector(-256.0f, 1728.0f, 88.993805f) },
		{ 3, new Vector(-352.0f, 1728.0f, 91.708435f) },
		{ 4, new Vector(-448.0f, 1728.0f, 93.399132f) },
		{ 5, new Vector(-512.0f, 1696.0f, 88.842323f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-328.0f, -2288.0f, -99.255737f) },
		{ 2, new Vector(-392.0f, -2224.0f, -99.255737f) },
		{ 3, new Vector(-456.0f, -2288.0f, -99.255737f) },
		{ 4, new Vector(-520.0f, -2224.0f, -99.255737f) },
		{ 5, new Vector(-584.0f, -2288.0f, -98.776489f) },
	};
}
