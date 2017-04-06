using System;
using PictOgr.Core.Commands;
using PictOgr.Core.CQRS.Bus;
using ICommand = System.Windows.Input.ICommand;

namespace PictOgr.SplashScreen.Commands
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
