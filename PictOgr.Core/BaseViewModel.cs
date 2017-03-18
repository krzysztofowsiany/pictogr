using System.ComponentModel;
using System.Runtime.CompilerServices;
using PictOgr.Core.CQRS.Query;
using PictOgr.Core.Properties;

namespace PictOgr.Core
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected readonly IQueryBus queryBus;

		public BaseViewModel(IQueryBus queryBus)
		{
			this.queryBus = queryBus;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string property_name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
		}
	}
}