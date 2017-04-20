using System;
using System.Windows.Input;
using CQRS.Bus.Command;
using CQRS.Bus.Event;
using PictOgr.Infrastructure.Commands.ExitApplication;
using PictOgr.Infrastructure.Events;

namespace PictOgr.MVVM.SplashScreen.Commands
{
	public class ExitApplicationCommand : ICommand
	{
		private readonly ICommandBus _commandBus;
		private readonly IEventBus _eventBus;

		public ExitApplicationCommand(ICommandBus commandBus,  IEventBus eventBus)
		{
			_commandBus = commandBus;
			_eventBus = eventBus;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_eventBus.Publish(new ExitApplicationEvent());
			_commandBus.SendCommand<ExitApplication>(new ExitApplication(0));
		}

		public event EventHandler CanExecuteChanged;
	}
}
