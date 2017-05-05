using System.Windows;
using CQRS.Bus.Event;
using PictOgr.Infrastructure.Events;
using PictOgr.MVVM.Configuration.ViewModels;

namespace PictOgr.MVVM.Configuration.Views
{
	public partial class ConfigurationView : Window
	{
		public ConfigurationView(ConfigurationViewModel configurationViewModel, IEventBus eventBus)
		{
			DataContext = configurationViewModel;

			eventBus.Register(new ExitApplicationEventHandler(() =>
			{
				Close();
			}));

			InitializeComponent();
		}
	}
}
