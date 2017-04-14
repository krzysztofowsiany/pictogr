namespace CQRS.Bus.Event
{
	using System;
	using System.Collections.Generic;
	using Autofac.Extras.NLog;
	using CQRS.Event;

	public class EventBus : IEventBus
	{
		private readonly ILogger logger;

		private static Dictionary<Type, List<object>> eventList = new Dictionary<Type, List<object>>();

		public EventBus(ILogger logger)
		{
			this.logger = logger;
		}

		public void Register<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
		{
			List<object> eventHandlers;

			if (!eventList.ContainsKey(typeof(TEvent)))
			{
				eventList.Add(typeof(TEvent), new List<object>());
			}

			if (!eventList.TryGetValue(typeof(TEvent), out eventHandlers))
			{
				return;
			}

			try
			{
				if (!eventHandlers.Contains(eventHandler))
				{
					eventHandlers.Add(eventHandler);
				}
			}
			catch (Exception e)
			{
				logger.Error(e);
			}
		}

		public void UnRegister<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
		{
			List<object> eventHandlers;

			if (!eventList.TryGetValue(typeof(TEvent), out eventHandlers))
			{
				throw new TypeUnloadedException(nameof(TEvent));
			}

			try
			{
				eventHandlers.Remove(eventHandler);

				if (eventHandlers.Count == 0)
				{
					eventList.Remove(typeof(TEvent));
				}
			}
			catch (Exception e)
			{
				logger.Error(e);
			}
		}

		public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
		{
			List<object> eventHandlers;
			if (!eventList.TryGetValue(typeof(TEvent), out eventHandlers))
			{
				throw new TypeUnloadedException(nameof(TEvent));
			}

			try
			{
				foreach (var eventHandler in eventHandlers)
				{
					(eventHandler as IEventHandler<TEvent>)?.Handle(@event);
				}
			}
			catch (Exception e)
			{
				logger.Error(e);
			}
		}
	}
}