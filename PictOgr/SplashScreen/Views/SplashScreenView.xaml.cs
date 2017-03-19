using System;
using System.Windows;
using PictOgr.SplashScreen.ViewModels;

namespace PictOgr.SplashScreen.Views
{
	/// <summary>
	/// Interaction logic for SplashScreenView.xaml
	/// </summary>
	public partial class SplashScreenView : Window
	{
		public SplashScreenView(SplashScreenViewModel splashScreenViewModel)
		{
			this.DataContext = splashScreenViewModel;

			splashScreenViewModel.RequestClose += (object sender, EventArgs args) =>
			{
				this.Close();
			};

			InitializeComponent();
		}
	}
}
