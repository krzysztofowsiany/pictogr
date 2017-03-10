namespace PictOgr.Core.CQRS.Command
{
    public interface ICommandBus
    {
        void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
