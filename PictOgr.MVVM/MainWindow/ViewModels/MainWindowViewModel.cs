using System.Windows.Input;
using Autofac.Extras.NLog;
using CQRS.Bus.Query;
using PictOgr.MVVM.MainWindow.Commands;

namespace PictOgr.MVVM.MainWindow.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private readonly ConfigurationCommand configurationCommand;

		public ICommand ConfigurationCommand => configurationCommand;

		public MainWindowViewModel(ConfigurationCommand configurationCommand, IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
			this.configurationCommand = configurationCommand;
		}
	}
}
