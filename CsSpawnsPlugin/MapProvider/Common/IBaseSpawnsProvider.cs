using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider.Common;
public interface IBaseSpawnsProvider
{
	string MapName { get; }
	Dictionary<int, Vector> CTSpawnCoordinates { get; }
	Dictionary<int, Vector> TSpawnCoordinates { get; }
}
