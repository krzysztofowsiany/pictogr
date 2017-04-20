using Autofac;
using PictOgr.GUI.SplashScreen.Commands;
using PictOgr.GUI.SplashScreen.ViewModels;
using PictOgr.GUI.SplashScreen.Views;

namespace PictOgr.GUI.SplashScreen
{
	public class SplashScreenModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ExitApplicationCommand>();
			builder.RegisterType<StartApplicationCommand>();
			builder.RegisterType<SplashScreenViewModel>();
			builder.RegisterType<SplashScreenView>();
		}
	}
}
