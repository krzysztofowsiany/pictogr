using System;
using System.Windows;
using PictOgr.MVVM.SplashScreen.ViewModels;

namespace PictOgr.MVVM.SplashScreen.Views
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
