using System;
using System.Windows.Input;

namespace PictOgr.MVVM.MainWindow.Commands
{
	public class CloseCommand : ICommand
	{
		public CloseCommand()
		{
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
		}

		public event EventHandler CanExecuteChanged;
	}
}
