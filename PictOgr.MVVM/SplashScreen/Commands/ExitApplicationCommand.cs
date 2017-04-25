using System;
using System.Windows.Input;
using CQRS.Bus.Command;
using PictOgr.Infrastructure.Commands.ExitApplication;

namespace PictOgr.MVVM.SplashScreen.Commands
{
	public class ExitApplicationCommand : ICommand
	{
		private readonly ICommandBus _commandBus;

		public ExitApplicationCommand(ICommandBus commandBus)
		{
			_commandBus = commandBus;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_commandBus.SendCommand<ExitApplication>(new ExitApplication(0));
		}

		public event EventHandler CanExecuteChanged;
	}
}
