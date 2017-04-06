using PictOgr.Core.CQRS.Command;

namespace PictOgr.Core.Commands
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
