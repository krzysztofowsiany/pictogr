using System;
using System.Windows;
using System.Windows.Input;

namespace PictOgr.SplashScreen.Commands
{
    public class ShowMessageBoxCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("asdfasdf");
        }

        public event EventHandler CanExecuteChanged;
    }
}
