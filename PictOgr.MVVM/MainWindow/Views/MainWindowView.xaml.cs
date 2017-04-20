using System.Windows;
using CQRS.Bus.Event;
using PictOgr.Infrastructure.Events;

namespace PictOgr.MVVM.MainWindow.Views
{
	/// <summary>
	/// Interaction logic for MainWindowView.xaml
	/// </summary>
	public partial class MainWindowView : Window
	{
		public MainWindowView(IEventBus eventBus)
		{
			InitializeComponent();
			eventBus.Register(new ExitApplicationEventHandler(() =>
			{
				Close();
			}));
		}
	}
}
