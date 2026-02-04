using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public abstract class BaseSpawnsTest
{
    public abstract IMapResolver? MapResolver { get; set; }
    public abstract IBaseSpawnsProvider BaseSpawnsProvider { get; }
    protected SpawnsPluginMock Mock { get; set; } = default!;

    //[AssemblyInitialize]
    //public static void AssemblyInit(TestContext context)
    //{
    //    // This method is called once for the test assembly, before any tests are run.
    //}

    //[AssemblyCleanup]
    //public static void AssemblyCleanup()
    //{
    //    // This method is called once for the test assembly, after all tests are run.
    //}

    //[ClassInitialize]
    //public static void ClassInit(TestContext context)
    //{
    //    // This method is called once for the test class, before any tests of the class are run.
    //}

    //[ClassCleanup]
    //public static void ClassCleanup()
    //{
    //    // This method is called once for the test class, after all tests of the class are run.
    //}

    [TestInitialize]
    public void TestInit()
    {
        MapResolver = new MapResolver([BaseSpawnsProvider]);
        Mock = new SpawnsPluginMock(MapResolver);
    }

    [TestCleanup]
    public void TestCleanup()
    {

    }
}
