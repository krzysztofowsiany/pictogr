
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PictOgr.Annotations;

namespace PictOgr.SplashScreen.ViewModels
{
    public class SplashScreenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
