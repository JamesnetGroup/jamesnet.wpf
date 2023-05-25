using Jamesnet.Wpf.Mvvm;
using System.Windows;

namespace Jamesnet.Wpf.Controls
{
    public interface IViewable
    {
        FrameworkElement View { get; init; }
        ObservableBase ViewModel { get; }
    }
}