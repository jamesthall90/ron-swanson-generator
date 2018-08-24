using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class InfrastructureAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Processor"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Dispatcher"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}