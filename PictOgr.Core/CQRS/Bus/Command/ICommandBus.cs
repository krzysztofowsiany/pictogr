namespace PictOgr.Core.CQRS.Bus.Command
{
    using CQRS.Command;

    public interface ICommandBus
	{
		void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
