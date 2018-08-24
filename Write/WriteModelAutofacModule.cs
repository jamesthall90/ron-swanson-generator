using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Write
{
    public class WriteModelAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Command"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Handler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}