using System;
using System.Windows.Input;

namespace PictOgr.MVVM.Base
{
	public class RelayCommand<TParam> : ICommand where TParam : class
	{
		private readonly Action<TParam> execute;
		private readonly Func<TParam, bool> canExecute;

		public RelayCommand(Action<TParam> execute, Func<TParam, bool> canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null || canExecute(parameter as TParam);
		}

		public void Execute(object parameter)
		{
			execute(parameter as TParam);
		}
	}

	public class RelayCommand : RelayCommand<object>
	{
		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
			: base(execute, canExecute)
		{
		}
	}
}
