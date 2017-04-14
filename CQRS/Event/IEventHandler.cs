namespace CQRS.Event
{
	public interface IEventHandler<TEvent> where TEvent : IEvent
	{
		void Handle(TEvent @event);
	}
}