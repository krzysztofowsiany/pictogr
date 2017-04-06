namespace PictOgr.SplashScreen.Commands
{
    using System;
    using System.Windows.Input;
    using Core;
    using MainWindow.Views;

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
