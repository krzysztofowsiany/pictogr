using System;
using PictOgr.Core;
using PictOgr.MainWindow.Views;
using ICommand = System.Windows.Input.ICommand;

namespace PictOgr.SplashScreen.Commands
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
