using System.Windows;
using PictOgr.SplashScreen.ViewModels;

namespace PictOgr.SplashScreen.Views
{
    /// <summary>
    /// Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        public SplashScreenView(SplashScreenViewModel splasg_screen_view_model)
        {
            this.DataContext = splasg_screen_view_model;

            InitializeComponent();
        }
    }
}
