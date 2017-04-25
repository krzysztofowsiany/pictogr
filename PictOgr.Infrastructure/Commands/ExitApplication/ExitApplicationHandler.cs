namespace PictOgr.Infrastructure.Commands.ExitApplication
{
    using Autofac.Extras.NLog;
    using CQRS.Bus.Event;
    using CQRS.Command;
    using Events;

    public class ExitApplicationHandler : ICommandHandler<ExitApplication>
    {
        private readonly ILogger _logger;

        private IEventBus _eventBus;

        public ExitApplicationHandler(ILogger logger, IEventBus eventBus)
        {
            _eventBus = eventBus;

            _logger = logger;
        }

        public void Handle(ExitApplication command)
        {
            _logger.Info("Exit application.");
            _eventBus.Publish(new ExitApplicationEvent(command.ExitCode));
            System.Environment.Exit(command.ExitCode);
        }
    }
}
