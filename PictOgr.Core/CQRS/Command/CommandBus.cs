using System;
using Autofac;

namespace PictOgr.Core.CQRS.Command
{
	public class CommandBus : ICommandBus
	{
		private readonly ILifetimeScope container;

		public CommandBus(ILifetimeScope container)
		{
			this.container = container;
		}

		public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			var commandHandler = container.ResolveOptional<ICommandHandler<TCommand>>();

			if (commandHandler == null)
			{
				throw new Exception($"Not found handler for Command: '{command.GetType().FullName}'");
			}

			commandHandler.Handle(command);
		}
	}
}
