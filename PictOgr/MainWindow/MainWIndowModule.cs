using Autofac;
using PictOgr.MainWindow.ViewModels;
using PictOgr.MainWindow.Views;

namespace PictOgr.MainWindow
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
