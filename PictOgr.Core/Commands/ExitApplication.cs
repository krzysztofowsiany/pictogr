using PictOgr.Core.CQRS.Command;

namespace PictOgr.Core.Commands
{
    public class ExitApplication : ICommand
    {
        public ExitApplication(int exitCode)
        {
            ExitCode = exitCode;
        }

        public int ExitCode { get; private set; }
    }
}
