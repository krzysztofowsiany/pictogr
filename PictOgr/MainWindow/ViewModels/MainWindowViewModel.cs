namespace PictOgr.MainWindow.ViewModels
{
	using CQRS.Bus.Query;
	using Autofac.Extras.NLog;
	using Core;

	public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
		}
	}
}
