namespace PictOgr.Core.CQRS.Bus
{
    using PictOgr.Core.CQRS.Event;

    public interface IEventBus
    {
        void Register<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        void UnRegister<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}

