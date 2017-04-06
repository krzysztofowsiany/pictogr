using Autofac.Extras.NLog;
using PictOgr.Core.CQRS.Command;

namespace PictOgr.Core.Commands
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
