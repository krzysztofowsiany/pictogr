using CQRS.Command;

namespace CQRS.Bus.Command
{
	public interface ICommandBus
	{
		void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
