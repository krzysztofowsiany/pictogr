namespace PictOgr.MainWindow.ViewModels
{
    using Autofac.Extras.NLog;
    using Core;
    using Core.CQRS.Bus.Query;

    public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
		}
	}
}
