using Autofac.Extras.NLog;
using CQRS.Command;

namespace PictOgr.Infrastructure.Commands
{
	public class ExitApplicationHandler : ICommandHandler<ExitApplication>
	{
		private readonly ILogger logger;

		public ExitApplicationHandler(ILogger logger)
		{
			this.logger = logger;
		}

		public void Handle(ExitApplication command)
		{
			logger.Info("Exit application.");
			System.Environment.Exit(command.ExitCode);
		}
	}
}
