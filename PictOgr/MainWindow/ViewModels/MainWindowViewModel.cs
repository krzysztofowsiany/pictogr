using Autofac.Extras.NLog;
using PictOgr.Core;
using PictOgr.Core.CQRS.Bus;

namespace PictOgr.MainWindow.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
		}
	}
}
