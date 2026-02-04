using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;
public interface IBaseSpawnsProvider
{
    public string MapName { get; }

    public CsTeam Team { get; }

    public Dictionary<int, Vector> SpawnCoordinates { get; }
}
