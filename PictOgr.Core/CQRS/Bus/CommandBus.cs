using System;
using Autofac;
using Autofac.Extras.NLog;
using PictOgr.Core.CQRS.Command;

namespace PictOgr.Core.CQRS.Bus
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope container;
        private readonly ILogger logger;

        public CommandBus(ILifetimeScope container, ILogger logger)
        {
            this.container = container;
            this.logger = logger;
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

            try
            {
                commandHandler.Handle(command);
            }
            catch (Exception e)
            {
                this.logger.Error(e);
            }
        }
    }
}
