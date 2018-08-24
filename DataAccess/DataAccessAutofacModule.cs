using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace DataAccess
{
    public class DataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Context"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}