using System.Windows;
using CQRS.Bus.Event;
using PictOgr.Infrastructure.Events;
using PictOgr.MVVM.MainWindow.ViewModels;

namespace PictOgr.MVVM.MainWindow.Views
{
	/// <summary>
	/// Interaction logic for MainWindowView.xaml
	/// </summary>
	public partial class MainWindowView : Window
	{
		public MainWindowView(MainWindowViewModel mainWindowView, IEventBus eventBus)
		{
			DataContext = mainWindowView;

			eventBus.Register(new ExitApplicationEventHandler(() =>
			{
				Close();
			}));

			InitializeComponent();
		}
	}
}
