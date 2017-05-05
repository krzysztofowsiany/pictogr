using System.Windows;
using CQRS.Bus.Event;
using PictOgr.Infrastructure.Events;

namespace PictOgr.MVVM.Configuration.Views
{
	/// <summary>
	/// Interaction logic for MainWindowView.xaml
	/// </summary>
	public partial class ConfigurationView : Window
	{
		public ConfigurationView(IEventBus eventBus)
		{
			InitializeComponent();
			eventBus.Register(new ExitApplicationEventHandler(() =>
			{
				Close();
			}));
		}
	}
}
