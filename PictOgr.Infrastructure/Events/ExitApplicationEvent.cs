using CQRS.Event;

namespace PictOgr.Infrastructure.Events
{
	public class ExitApplicationEvent : IEvent
	{
	    public ExitApplicationEvent(int exitCode)
	    {
	        
	    }
	}
}
