using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public class SpawnsPluginMock(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
{
    public static string ModuleName => "Main";

    public static string ModuleVersion => "1.0";

    public void Load()
    {
        Console.WriteLine("Plugin loaded successfully!");
    }

    public Vector? CommandSpawn(string command, string mapName, CsTeam team)
    {
        var selectedSpawn = Convert.ToInt32(command.Split(' ')[1]);
        return mapResolver?.GetSpawn(mapName, team, selectedSpawn);
    }
}
