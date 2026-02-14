using CounterStrikeSharp.API.Core;
using CsSpawnsPlugin.Handlers;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.MapProvider.Common;
using CsSpawnsPlugin.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace CsSpawnsPlugin.IoC;
public class DependencyInjection : IPluginServiceCollection<SpawnsPlugin>
{
	public void ConfigureServices(IServiceCollection serviceCollection)
	{
		RegisterMapResolver(serviceCollection);
		RegisterMapSpawns(serviceCollection);
		RegisterHandlers(serviceCollection);
	}

	private static void RegisterMapResolver(IServiceCollection services)
	{
		services.AddScoped<IMapResolver, MapResolver>();
	}

	private static void RegisterMapSpawns(IServiceCollection services)
	{
		services.AddScoped<IBaseSpawnsProvider, MirageSpawnsProvider>();
	}

	private static void RegisterHandlers(IServiceCollection services)
	{
		services.AddScoped<ISpawnCommandHandler, SpawnCommandHandler>();
	}
}
