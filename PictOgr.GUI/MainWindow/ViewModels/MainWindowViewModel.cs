using Autofac.Extras.NLog;
using CQRS.Bus.Query;
using PictOgr.Core;

namespace PictOgr.GUI.MainWindow.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
		}
	}
}
