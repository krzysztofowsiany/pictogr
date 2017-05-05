using Autofac.Extras.NLog;
using CQRS.Bus.Query;

namespace PictOgr.MVVM.Configuration.ViewModels
{
	public class ConfigurationViewModel : BaseViewModel
	{
		public ConfigurationViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
		}
	}
}
