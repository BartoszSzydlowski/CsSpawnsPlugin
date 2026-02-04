using CounterStrikeSharp.API.Modules.Utils;

namespace CsSpawnsPlugin.MapProvider;
public class MirageCtSpawnsProvider : BaseSpawnsProvider
{
    public override string MapName => "de_mirage";

    public override CsTeam Team => CsTeam.CounterTerrorist;

    public override Dictionary<int, Vector> SpawnCoordinates => new()
    {
        { 1, new Vector(1216.00f, -115.00f, -160.95f) },
        { 2, new Vector(1216.00f, -211.00f, -158.60f) },
        { 3, new Vector(1136.00f, 32.000f, -158.78f) },
        { 4, new Vector(1136.00f, -64.00f, -158.69f) },
        { 5, new Vector(1136.00f, -256.00f, -158.83f) },
    };
}
