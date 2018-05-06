using PropertyChanged;
using System.ComponentModel;

namespace FileExplorer.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged = ( sender, e ) => {};
    }
}