using System;
using CQRS.Event;

namespace PictOgr.Infrastructure.Events
{
	public class ExitApplicationEventHandler:IEventHandler<ExitApplicationEvent>
	{
		private readonly Action action;

		public ExitApplicationEventHandler(Action action)
		{
			this.action = action;
		}

		public void Handle(ExitApplicationEvent @event)
		{
			action();
		}
	}
}
