using Autofac;
using PictOgr.MVVM.Configuration.ViewModels;
using PictOgr.MVVM.Configuration.Views;

namespace PictOgr.MVVM.Configuration
{
	public class ConfigurationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ConfigurationViewModel>();
			builder.RegisterType<ConfigurationView>();
		}
	}
}
