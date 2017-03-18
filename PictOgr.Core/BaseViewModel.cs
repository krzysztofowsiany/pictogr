using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autofac.Extras.NLog;
using PictOgr.Core.CQRS.Bus;
using PictOgr.Core.Properties;

namespace PictOgr.Core
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected readonly IQueryBus QueryBus;
		protected readonly ILogger Logger;

		public BaseViewModel(IQueryBus queryBus, ILogger logger)
		{
			QueryBus = queryBus;
			Logger = logger;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}