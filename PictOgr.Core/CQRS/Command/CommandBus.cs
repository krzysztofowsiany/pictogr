using System;
using Autofac;

namespace PictOgr.Core.CQRS.Command
{
    public class CommandBus : ICommandBus
    {


        public CommandBus()
        {

        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                return;

            var commandHandler = resolveEventArgs.ResolveOptional<ICommandHandler<TCommand>>();
            if (commandHandler == null)
                return;

            commandHandler.Handle(cmd);

        }
    }
}
