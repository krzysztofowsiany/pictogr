using PictOgr.Core.CQRS.Command;

namespace PictOgr.Core.Commands
{
	public class ExitCommand:ICommand
	{
		public ExitCommand(int exitCode)
		{
			ExitCode = exitCode;
		}

		public int ExitCode { get; private set; }
	}
}
