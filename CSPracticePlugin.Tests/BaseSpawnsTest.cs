using CSPracticePlugin.IoC;
using CSPracticePlugin.MapProvider.Common;
using CSPracticePlugin.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace CSPracticePlugin.Tests;

public abstract class BaseSpawnsTest<T> where T : IBaseSpawnsProvider
{
	public abstract string MapName { get; }
	protected SpawnsPluginMock Mock { get; set; } = default!;
	private IMapResolver _mapResolver = default!;

	[TestInitialize]
	public void TestInit()
	{
		var services = new ServiceCollection();
		new DependencyInjection().ConfigureServices(services);
		var provider = services.BuildServiceProvider();
		_mapResolver = provider.GetRequiredService<IMapResolver>();
		Mock = new SpawnsPluginMock(_mapResolver)
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