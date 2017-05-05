using Autofac;
using PictOgr.MVVM.Base;
using PictOgr.MVVM.SplashScreen.Commands;
using PictOgr.MVVM.SplashScreen.ViewModels;
using PictOgr.MVVM.SplashScreen.Views;

namespace PictOgr.MVVM.SplashScreen
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
