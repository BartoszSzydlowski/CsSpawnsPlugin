using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;
public interface IBaseSpawnsProvider
{
	public string MapName { get; }
	public Dictionary<int, Vector> CTSpawnCoordinates { get; }
	public Dictionary<int, Vector> TSpawnCoordinates { get; }
}
