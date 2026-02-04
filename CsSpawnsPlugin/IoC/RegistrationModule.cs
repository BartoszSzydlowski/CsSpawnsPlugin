using Autofac;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.IoC;

public class RegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IBaseSpawnsProvider).Assembly)
           .AsImplementedInterfaces()
           .InstancePerLifetimeScope();

        builder.RegisterType<MapResolver>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
