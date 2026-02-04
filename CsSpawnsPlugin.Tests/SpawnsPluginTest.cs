using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class SpawnsPluginTest : BaseTest
{
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange: simple stubs for required dependencies
        var provider = new FakeBaseSpawnsProvider();
        var resolver = new FakeMapResolver(provider);

        // Act: create the plugin mock with dependencies and call the test loader
        var main = new SpawnsPluginMock(resolver, provider);
        main.LoadMock(true);

        // Assert: if you have any state to assert, do it here (example omitted)
    }

    private class FakeMapResolver : IMapResolver
    {
        private readonly IBaseSpawnsProvider _provider;
        public FakeMapResolver(IBaseSpawnsProvider provider) => _provider = provider;
        public IBaseSpawnsProvider Resolve(string mapName) => _provider;
    }

    private class FakeBaseSpawnsProvider : IBaseSpawnsProvider
    {
        public string MapName => "de_mirage";
        public Dictionary<int, System.Numerics.Vector3> TSpawnCoordinates { get; } = new();
        public Dictionary<int, System.Numerics.Vector3> CTSpawnCoordinates { get; } = new();

        public FakeBaseSpawnsProvider()
        {
            TSpawnCoordinates[1] = new System.Numerics.Vector3(0, 0, 0);
            CTSpawnCoordinates[1] = new System.Numerics.Vector3(0, 0, 0);
        }
    }
}

