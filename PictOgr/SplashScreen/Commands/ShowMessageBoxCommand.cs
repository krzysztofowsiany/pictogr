using System;
using System.Windows;
using PictOgr.Core.CQRS.Command;
using ICommand = System.Windows.Input.ICommand;

namespace PictOgr.SplashScreen.Commands
{
    public class ShowMessageBoxCommand : ICommand
    {
        private readonly ICommandBus command_bus;

        public ShowMessageBoxCommand(ICommandBus command_bus)
        {
            this.command_bus = command_bus;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("asdfasdf");
            //CQRS
            //command_bus.SendCommand();
        }

        public event EventHandler CanExecuteChanged;
    }
}
