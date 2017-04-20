using System;
using System.Windows;
using PictOgr.GUI.SplashScreen.ViewModels;

namespace PictOgr.GUI.SplashScreen.Views
{
	public partial class SplashScreenView : Window
	{
		public SplashScreenView(SplashScreenViewModel splashScreenViewModel)
		{
			DataContext = splashScreenViewModel;

			splashScreenViewModel.RequestClose += (object sender, EventArgs args) =>
			{
				Close();
			};

			InitializeComponent();
		}
	}
}
