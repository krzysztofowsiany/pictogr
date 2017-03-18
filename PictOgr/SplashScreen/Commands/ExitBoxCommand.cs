using System;
using PictOgr.Core.Commands;
using PictOgr.Core.CQRS.Bus;
using ICommand = System.Windows.Input.ICommand;

namespace PictOgr.SplashScreen.Commands
{
	public class ExitBoxCommand : ICommand
	{
		private readonly ICommandBus commandBus;

		public ExitBoxCommand(ICommandBus commandBus)
		{
			this.commandBus = commandBus;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			commandBus.SendCommand<ExitCommand>(new ExitCommand(0));
		}

		public event EventHandler CanExecuteChanged;
	}
}
