using Autofac;

namespace CsSpawnsPlugin.IoC;
public static class AutofacExtensions
{
    public static void RegisterCsSpawnsPlugin(this ContainerBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.RegisterModule(new RegistrationModule());
    }
}
