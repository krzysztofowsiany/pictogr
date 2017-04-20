using System.Windows;
using Autofac;
using PictOgr.Infrastructure.AutoFac;
using PictOgr.MVVM.SplashScreen.Views;

namespace PictOgr
{
	public partial class App : Application
	{
		private void OnStartup(object sender, StartupEventArgs e)
		{
			var container = Container.CreateBuilder().Build();

			var splashScreenView = container.Resolve<SplashScreenView>();

			splashScreenView.Show();
		}
	}
}
