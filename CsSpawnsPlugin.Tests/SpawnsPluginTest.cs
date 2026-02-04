using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class SpawnsPluginTest : BaseTest
{
    private readonly IMapResolver mapResolver;
    private readonly IEnumerable<IBaseSpawnsProvider> spawnsProvider;


    [TestMethod]
    public void TestMethod1()
    {

    }

    [TestMethod]
    public void Load_ShouldNotThrowAnd_MapNameShouldBeDeMirage()
    {
        // Arrange
        var sut = new SpawnsPluginMock();

        // Act
        sut.Load(false); // should resolve provider and not throw

        // Assert
        Assert.AreEqual("de_mirage", sut.MapName, "SpawnsPluginMock.MapName should be initialized to the test map.");
    }

    private class MirageSpawnsProviderMock : BaseSpawnsProvider
    {
        public override string MapName => "de_mirage";

        public override Dictionary<int, System.Numerics.Vector3> TSpawnCoordinates { get; } = new()
        {
            { 1, new System.Numerics.Vector3(0, 0, 0) },
            { 2, new System.Numerics.Vector3(0, 0, 0) }
        };

        public override Dictionary<int, System.Numerics.Vector3> CTSpawnCoordinates { get; } = new()
        {
            { 1, new System.Numerics.Vector3(0, 0, 0) },
            { 2, new System.Numerics.Vector3(0, 0, 0) }
        };
    }
}

