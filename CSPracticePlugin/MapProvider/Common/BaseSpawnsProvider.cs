using CounterStrikeSharp.API.Modules.Utils;

namespace CSPracticePlugin.MapProvider.Common;

public abstract class BaseSpawnsProvider : IBaseSpawnsProvider
{
	public abstract string MapName { get; }
	public abstract Dictionary<int, Vector> CTSpawnCoordinates { get; }
	public abstract Dictionary<int, Vector> TSpawnCoordinates { get; }
}