using CsSpawnsPlugin.IoC;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace CsSpawnsPlugin.Tests;

public abstract class BaseSpawnsTest<T> where T : IBaseSpawnsProvider
{
	private T spawnProvider = default!;
	private IMapResolver mapResolver = default!;
	protected SpawnsPluginMock Mock { get; set; } = default!;

	//private IBaseSpawnsProvider[] providers = default!;

	public abstract string MapName { get; }


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
		var services = new ServiceCollection();
		new DependencyInjection().ConfigureServices(services);
		var provider = services.BuildServiceProvider();
		mapResolver = provider.GetRequiredService<IMapResolver>();
		//providers = [.. provider.GetRequiredService<IEnumerable<IBaseSpawnsProvider>>()];
		//mapResolver = new MapResolver(providers);
		Mock = new SpawnsPluginMock(mapResolver)
		{
			MapName = MapName
		};
		Mock.Load(true);
	}

	[TestCleanup]
	public void TestCleanup()
	{
		//DisposeIfNeeded(Mock);
		//DisposeIfNeeded(providers);
		//DisposeIfNeeded(mapResolver);
		//DisposeIfNeeded(spawnProvider);

		//if (providers is not null)
		//{
		//	foreach (var p in providers)
		//	{
		//		DisposeIfNeeded(p);
		//	}
		//}

		//Mock = null!;
		//mapResolver = null!;
		//spawnProvider = default!;
	}

	//private void DisposeIfNeeded(object? obj)
	//{
	//	if (obj is IDisposable disposable)
	//	{
	//		try
	//		{
	//			disposable.Dispose();
	//		}
	//		catch
	//		{

	//		}
	//	}
}
