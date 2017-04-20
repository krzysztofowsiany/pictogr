using Autofac.Extras.NLog;
using CQRS.Bus.Query;

namespace PictOgr.MVVM.MainWindow.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
		}
	}
}
