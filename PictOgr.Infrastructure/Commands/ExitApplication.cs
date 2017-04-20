using CQRS.Command;

namespace PictOgr.Infrastructure.Commands
{
	public class ExitApplication : ICommand
	{
		public int ExitCode { get; private set; }

		public ExitApplication(int exitCode)
		{
			ExitCode = exitCode;
		}
	}
}
