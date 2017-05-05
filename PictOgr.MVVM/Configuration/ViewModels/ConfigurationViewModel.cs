using System.Windows.Input;
using Autofac.Extras.NLog;
using CQRS.Bus.Query;
using PictOgr.MVVM.Base;

namespace PictOgr.MVVM.Configuration.ViewModels
{
	public class ConfigurationViewModel : BaseViewModel
	{
		private string pathFormat;

		public string PathFormat
		{
			get { return pathFormat; }
			set
			{
				pathFormat = value;
				OnPropertyChanged(nameof(PathFormat));
			}
		}

		public ICommand AddNameModuleCommand { get; private set; }

		public ConfigurationViewModel(IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
			PathFormat = string.Empty;

			AddNameModuleCommand = new RelayCommand(AddNameModule);
		}

		private void AddNameModule(object parameter)
		{
			var nameModule = parameter.ToString();

			PathFormat += nameModule;

		}
	}
}
