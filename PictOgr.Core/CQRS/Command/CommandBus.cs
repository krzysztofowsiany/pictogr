using System;
using Autofac;

namespace PictOgr.Core.CQRS.Command
{
    public class CommandBus : ICommandBus
    {
        private readonly IComponentContext container;

        public CommandBus(IComponentContext container)
        {
            this.container = container;
        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var command_handler = container.ResolveOptional<ICommandHandler<TCommand>>();

            if (command_handler == null)
            {
                throw new Exception($"Not found handler for Command: '{command.GetType().FullName}'");
            }

            command_handler.Handle(command);
        }
    }
}
