using System.Windows;
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
            new SplashScreenView().Show();
        }
    }
}
