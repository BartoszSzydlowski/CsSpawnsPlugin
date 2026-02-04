using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class SpawnsPluginTest : BaseTest
{
    private IMapResolver? mapResolver;
    private IBaseSpawnsProvider baseSpawnsProvider = new MirageSpawnsProviderMock();

    [TestMethod]
    public void Load_ShouldNotThrowAnd_MapNameShouldBeDeMirage()
    {
        mapResolver = new MapResolver([baseSpawnsProvider]);
        var mock = new SpawnsPluginMock(mapResolver, baseSpawnsProvider);
    }

    private class MirageSpawnsProviderMock : MirageSpawnsProvider
    {

    }
}

