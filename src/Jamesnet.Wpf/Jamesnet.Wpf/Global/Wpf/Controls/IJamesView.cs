using Jamesnet.Wpf.Mvvm;
using System.Windows;

namespace Jamesnet.Wpf.Controls
{
    public interface IJamesView
    {
        FrameworkElement View { get; init; }
        ObservableBase ViewModel { get; }
        void AutoWireViewModelChanged(object view, object dataContext);
    }
}