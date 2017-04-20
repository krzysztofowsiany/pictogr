using Autofac;
using PictOgr.MVVM.MainWindow.ViewModels;
using PictOgr.MVVM.MainWindow.Views;

namespace PictOgr.MVVM.MainWindow
{
	public class MainWindowModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<MainWindowViewModel>();
			builder.RegisterType<MainWindowView>();
		}
	}
}
