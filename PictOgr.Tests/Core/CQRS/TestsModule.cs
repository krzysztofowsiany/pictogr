using System.Reflection;
using Autofac;
using PictOgr.Core.CQRS.Command;
using PictOgr.Core.CQRS.Query;
using Module = Autofac.Module;

namespace PictOgr.Tests.Core.CQRS
{
    public class TestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentdomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
            var getassemblies = currentdomain.GetType().GetRuntimeMethod("GetAssemblies", new System.Type[] { });
            var assemblies = getassemblies.Invoke(currentdomain, new object[] { }) as Assembly[];
            for (var i = 0; i < assemblies.Length; i++)
            {
                if (assemblies[i].GetName().Name == "PictOgr")
                {
                    builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(ICommandHandler<>)).SingleInstance().PropertiesAutowired();
                    builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(IQueryHandler<,>)).SingleInstance().PropertiesAutowired();
                }
            }

        }
    }
}
