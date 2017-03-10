using Autofac;
using PictOgr.SplashScreen.Commands;
using PictOgr.SplashScreen.ViewModels;
using PictOgr.SplashScreen.Views;

namespace PictOgr.SplashScreen
{
    public class SplashScreenModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShowMessageBoxCommand>();


            builder.RegisterType<SplashScreenViewModel>();
            builder.RegisterType<SplashScreenView>();
            
            
        }
    }
}
