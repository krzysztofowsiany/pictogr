using System.Windows;
using Autofac;
using PictOgr.GUI.SplashScreen.Views;
using PictOgr.Infrastructure.AutoFac;

namespace PictOgr.GUI
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
