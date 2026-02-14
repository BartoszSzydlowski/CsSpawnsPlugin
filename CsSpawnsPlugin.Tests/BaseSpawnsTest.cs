using CsSpawnsPlugin.IoC;
using CsSpawnsPlugin.MapProvider.Common;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace CsSpawnsPlugin.Tests;

public abstract class BaseSpawnsTest<T> where T : IBaseSpawnsProvider
{
	public abstract string MapName { get; }
	protected SpawnsPluginMock Mock { get; set; } = default!;
	private IMapResolver mapResolver = default!;

	[TestInitialize]
	public void TestInit()
	{
		var services = new ServiceCollection();
		new DependencyInjection().ConfigureServices(services);
		var provider = services.BuildServiceProvider();
		mapResolver = provider.GetRequiredService<IMapResolver>();
		Mock = new SpawnsPluginMock(mapResolver)
		{
			MapName = MapName
		};
		Mock.Load(true);
	}

	[TestCleanup]
	public void TestCleanup()
	{

	}
}
