using System.Reflection;
using CQRS;

namespace PictOgr.Core.AutoFac
{
	using System;
	using System.IO;
	using System.Linq;
	using Autofac;
	using Autofac.Core;

	public static class Container
	{
		public static ContainerBuilder CreateBuilder()
		{
			var builder = new ContainerBuilder();

			LoadDLLs();

			LoadModules(builder);

			return builder;
		}

		private static void LoadDLLs()
		{
			foreach (var filePath in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
			{
				var fileName = Path.GetFileNameWithoutExtension(filePath);


				AppDomain.CurrentDomain.Load(fileName);
			}
		}

		private static void LoadModules(ContainerBuilder builder)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => !a.FullName.Contains("xunit"));

			var types = assemblies
				.SelectMany(x => x.GetTypes())
				.Where(t => t.IsAssignableTo<IModule>() && t.IsClass && !t.IsAbstract).ToList();

			builder.RegisterModule(new CQRSModule(Assembly.GetExecutingAssembly()));

			foreach (var type in types)
			{
				if (!type.Name.Equals("CQRSModule"))
				{
					builder.RegisterModule((IModule) Activator.CreateInstance(type));
				}
			}
		}
	}
}
