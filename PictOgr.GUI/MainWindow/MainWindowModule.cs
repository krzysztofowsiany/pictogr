using Autofac;
using PictOgr.GUI.MainWindow.ViewModels;
using PictOgr.GUI.MainWindow.Views;

namespace PictOgr.GUI.MainWindow
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
