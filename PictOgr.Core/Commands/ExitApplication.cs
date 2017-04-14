namespace PictOgr.Core.Commands
{
	using CQRS.Command;

	public class ExitApplication : ICommand
	{
		public int ExitCode { get; private set; }

		public ExitApplication(int exitCode)
		{
			ExitCode = exitCode;
		}
	}
}
