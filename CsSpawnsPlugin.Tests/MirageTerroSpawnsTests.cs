using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class MirageTerroSpawnsTests : BaseSpawnsTest
{
    private IMapResolver? mapResolver;
    private readonly IBaseSpawnsProvider baseSpawnsProvider = new MirageTerroSpawnsProvider();

    [TestMethod]
    public void Load_ShouldNotThrow()
    {
        mapResolver = new MapResolver([baseSpawnsProvider]);
        var mock = new SpawnsPluginMock(mapResolver, baseSpawnsProvider);
        mock.Load();
    }

    [DataRow(".spawn 2", "de_mirage", CsTeam.Terrorist)]
    //[DataRow(".spawn 6", "de_mirage", CsTeam.Terrorist)]
    [TestMethod]
    public void SpawnCommand_ShouldNotThrow(string spawn, string mapName, CsTeam team)
    {
        mapResolver = new MapResolver([baseSpawnsProvider]);
        var mock = new SpawnsPluginMock(mapResolver, baseSpawnsProvider);
        mock.Load();
        var result = mock.CommandSpawn(spawn, mapName, team);

        var expected = new Vector(1216.00f, -211.00f, -158.60f).ToString();

        Assert.IsNotNull(result);
        Assert.AreEqual(expected, result.ToString());
    }

    [DataRow(".spawn 22", "de_mirage", CsTeam.Terrorist)]
    [TestMethod]
    public void SpawnCommand_ShouldReturnNull(string spawn, string mapName, CsTeam team)
    {
        mapResolver = new MapResolver([baseSpawnsProvider]);
        var mock = new SpawnsPluginMock(mapResolver, baseSpawnsProvider);
        mock.Load();
        var result = mock.CommandSpawn(spawn, mapName, team);

        Assert.IsNull(result);
    }
}

