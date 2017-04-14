using PictOgr.Core.CQRS.Command;

namespace PictOgr.Core.CQRS.Bus
{
	public interface ICommandBus
	{
		void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
