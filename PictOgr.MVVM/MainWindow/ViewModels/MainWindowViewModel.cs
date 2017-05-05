using System.Windows.Input;
using Autofac.Extras.NLog;
using CQRS.Bus.Query;
using PictOgr.MVVM.Base;
using PictOgr.MVVM.MainWindow.Commands;

namespace PictOgr.MVVM.MainWindow.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private readonly ConfigurationCommand configurationCommand;
		private readonly ExitApplicationCommand exitApplicationCommand;

		public ICommand ConfigurationCommand => configurationCommand;
		public ICommand ExitApplicationCommand => exitApplicationCommand;

		public MainWindowViewModel(ConfigurationCommand configurationCommand, ExitApplicationCommand exitApplicationCommand,
			IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
			this.configurationCommand = configurationCommand;
			this.exitApplicationCommand = exitApplicationCommand;
		}
	}
}
