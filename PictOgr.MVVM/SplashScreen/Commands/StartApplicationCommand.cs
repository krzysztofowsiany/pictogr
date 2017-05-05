using System;
using System.Windows.Input;
using PictOgr.MVVM.Base;
using PictOgr.MVVM.MainWindow.Views;

namespace PictOgr.MVVM.SplashScreen.Commands
{
	public class StartApplicationCommand : ICommand
	{
		private readonly MainWindowView mainWindowView;

		public StartApplicationCommand(MainWindowView mainWindowView)
		{
			this.mainWindowView = mainWindowView;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object viewModel)
		{
			var baseViewModel = viewModel as BaseViewModel;

			baseViewModel?.OnRequestClose();

			mainWindowView.Show();
		}

		public event EventHandler CanExecuteChanged;
	}
}
