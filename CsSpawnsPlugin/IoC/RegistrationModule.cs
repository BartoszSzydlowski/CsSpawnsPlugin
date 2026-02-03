using Autofac;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.IoC;

public class RegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IBaseMapProvider).Assembly)
           .AsImplementedInterfaces()
           .InstancePerLifetimeScope();
    }
}
