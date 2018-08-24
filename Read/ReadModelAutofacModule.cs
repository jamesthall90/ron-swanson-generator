using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Read
{
    public class ReadModelAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Query"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}