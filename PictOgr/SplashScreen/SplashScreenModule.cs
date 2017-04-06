using Autofac;
using PictOgr.SplashScreen.Commands;
using PictOgr.SplashScreen.ViewModels;
using PictOgr.SplashScreen.Views;

namespace PictOgr.SplashScreen
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
