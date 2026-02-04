using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class MirageCtSpawnsTests : BaseSpawnsTest
{
    //private IMapResolver? mapResolver;
    //private readonly IBaseSpawnsProvider baseSpawnsProvider = new MirageCtSpawnsProvider();

    public override IMapResolver? MapResolver { get; set; }
    public override IBaseSpawnsProvider BaseSpawnsProvider => new MirageCtSpawnsProvider();

    [TestMethod]
    public void Load_ShouldNotThrow()
    {
        //MapResolver = new MapResolver([BaseSpawnsProvider]);
        //var mock = new SpawnsPluginMock(MapResolver);
        //mock.Load();
        Mock.Load();
    }

    [DataRow(".spawn 2", "de_mirage", CsTeam.CounterTerrorist)]
    [TestMethod]
    public void SpawnCommand_ShouldNotThrow(string spawn, string mapName, CsTeam team)
    {
        //mapResolver = new MapResolver([baseSpawnsProvider]);
        //var mock = new SpawnsPluginMock(mapResolver);
        //mock.Load();
        Mock.Load();
        var result = Mock.CommandSpawn(spawn, mapName, team);

        var expected = new Vector(1216.00f, -211.00f, -158.60f).ToString();

        Assert.IsNotNull(result);
        Assert.AreEqual(expected, result.ToString());
    }

    [DataRow(".spawn 22", "de_mirage", CsTeam.CounterTerrorist)]
    [TestMethod]
    public void SpawnCommand_ShouldReturnNull(string spawn, string mapName, CsTeam team)
    {
        //mapResolver = new MapResolver([baseSpawnsProvider]);
        //var mock = new SpawnsPluginMock(mapResolver);
        //mock.Load();
        Mock.Load();
        var result = Mock.CommandSpawn(spawn, mapName, team);

        Assert.IsNull(result);
    }
}
