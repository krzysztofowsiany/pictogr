
using System.Windows.Input;
using PictOgr.Core;
using PictOgr.SplashScreen.Commands;

namespace PictOgr.SplashScreen.ViewModels
{
    public class SplashScreenViewModel : BaseViewModel
    {
        private ShowMessageBoxCommand message_box_command;

        public ICommand MessageBoxCommand => message_box_command;

        public SplashScreenViewModel(ShowMessageBoxCommand message_box_command)
        {
            this.message_box_command = message_box_command;
        }
    }
}
