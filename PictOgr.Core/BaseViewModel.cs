using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autofac.Extras.NLog;
using PictOgr.Core.Properties;

namespace PictOgr.Core
{
    using PictOgr.Core.CQRS.Bus.Query;

    public class BaseViewModel : INotifyPropertyChanged
	{
		protected readonly IQueryBus QueryBus;
		protected readonly ILogger Logger;
		public event EventHandler RequestClose;

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

		public void OnRequestClose()
		{
			RequestClose?.Invoke(this, EventArgs.Empty);
		}
	}
}