using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class SpawnsPluginTest : BaseTest
{
    private IMapResolver? mapResolver;
    private readonly IBaseSpawnsProvider baseSpawnsProvider = new MirageSpawnsProviderMock();

    [TestMethod]
    public void Load_ShouldNotThrow()
    {
        mapResolver = new MapResolver([baseSpawnsProvider]);
        var mock = new SpawnsPluginMock(mapResolver, baseSpawnsProvider);
    }

    private class MirageSpawnsProviderMock : MirageSpawnsProvider
    {

    }
}

