using System;
using System.Windows;
using CQRS.Bus.Event;
using PictOgr.Infrastructure.Events;
using PictOgr.MVVM.SplashScreen.ViewModels;

namespace PictOgr.MVVM.SplashScreen.Views
{
	public partial class SplashScreenView : Window
	{
		public SplashScreenView(SplashScreenViewModel splashScreenViewModel, IEventBus eventBus)
		{
			DataContext = splashScreenViewModel;

			eventBus.Register(new ExitApplicationEventHandler(() =>
			{
				Close();
			}));

			InitializeComponent();
		}
	}
}
