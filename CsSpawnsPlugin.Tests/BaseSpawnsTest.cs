using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public abstract class BaseSpawnsTest<T> where T : IBaseSpawnsProvider
{
	private T spawnProvider = default!;
	private IMapResolver? MapResolver { get; set; }
	protected SpawnsPluginMock Mock { get; set; } = default!;

	private readonly IBaseSpawnsProvider[] providers =
	[
		new MirageTerroSpawnsProvider(),
		new MirageCtSpawnsProvider(),
	];


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
		MapResolver = new MapResolver(providers);
		Mock = new SpawnsPluginMock(MapResolver, spawnProvider);
	}

	[TestCleanup]
	public void TestCleanup()
	{
		DisposeIfNeeded(Mock);
		DisposeIfNeeded(MapResolver);
		DisposeIfNeeded(spawnProvider);

		if (providers is not null)
		{
			foreach (var p in providers)
			{
				DisposeIfNeeded(p);
			}
		}

		Mock = null!;
		MapResolver = null;
		spawnProvider = default!;
	}

	private void DisposeIfNeeded(object? obj)
	{
		if (obj is IDisposable disposable)
		{
			try
			{
				disposable.Dispose();
			}
			catch
			{

			}
		}
	}
}
