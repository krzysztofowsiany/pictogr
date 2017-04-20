using System;
using System.Windows.Input;
using CQRS.Bus.Command;
using PictOgr.Infrastructure.Commands;

namespace PictOgr.MVVM.SplashScreen.Commands
{
	public class ExitApplicationCommand : ICommand
	{
		private readonly ICommandBus commandBus;

		public ExitApplicationCommand(ICommandBus commandBus)
		{
			this.commandBus = commandBus;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			commandBus.SendCommand<ExitApplication>(new ExitApplication(0));
		}

		public event EventHandler CanExecuteChanged;
	}
}
