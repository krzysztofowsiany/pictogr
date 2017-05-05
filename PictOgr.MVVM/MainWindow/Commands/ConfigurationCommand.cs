using System;
using System.Windows.Input;
using PictOgr.MVVM.Base;
using PictOgr.MVVM.Configuration.Views;

namespace PictOgr.MVVM.MainWindow.Commands
{
	public class ConfigurationCommand : ICommand
	{
		private readonly ConfigurationView configurationView;

		public ConfigurationCommand(ConfigurationView configurationView)
		{
			this.configurationView = configurationView;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object viewModel)
		{
			var baseViewModel = viewModel as BaseViewModel;

			baseViewModel?.OnRequestClose();

			configurationView.Show();
		}

		public event EventHandler CanExecuteChanged;
	}
}
