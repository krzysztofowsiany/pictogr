using System.Windows;
using Autofac;
using PictOgr.Core.AutoFac;
using PictOgr.SplashScreen.Views;

namespace PictOgr
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var container = Container.CreateBuilder().Build();

            var splash_screen_view = container.Resolve<SplashScreenView>();

            splash_screen_view.Show();
        }
    }
}
