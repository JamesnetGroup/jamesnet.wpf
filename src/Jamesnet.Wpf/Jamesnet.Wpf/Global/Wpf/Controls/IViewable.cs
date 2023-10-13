using System.ComponentModel;
using System.Windows;

namespace Jamesnet.Wpf.Controls;
public interface IViewable
{
    FrameworkElement View { get; }
    INotifyPropertyChanged ViewModel { get; }
}