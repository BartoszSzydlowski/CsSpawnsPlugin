using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.Consts;

namespace CsSpawnsPlugin.MapProvider;
public class AncientSpawnsProvider : BaseSpawnsProvider
{
	public override string MapName => MapNames.Ancient;

	public override Dictionary<int, Vector> CTSpawnCoordinates => new()
	{
		{ 1, new Vector(-192f, 1696f, 88.793152f) },
		{ 2, new Vector(-256f, 1728f, 88.993805f) },
		{ 3, new Vector(-352f, 1728f, 91.708435f) },
		{ 4, new Vector(-448f, 1728f, 93.399132f) },
		{ 5, new Vector(-512f, 1696f, 88.842323f) },
	};

	public override Dictionary<int, Vector> TSpawnCoordinates => new()
	{
		{ 1, new Vector(-328f, -2288f, -99.255737f) },
		{ 2, new Vector(-392f, -2224f, -99.255737f) },
		{ 3, new Vector(-456f, -2288f, -99.255737f) },
		{ 4, new Vector(-520f, -2224f, -99.255737f) },
		{ 5, new Vector(-584f, -2288f, -98.776489f) },
	};
}
