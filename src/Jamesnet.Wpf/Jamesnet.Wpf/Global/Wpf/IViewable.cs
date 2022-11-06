using System.Windows;

namespace Jamesnet.Wpf.Controls
{
    public interface IViewable
    {
        FrameworkElement View { get; init; }
        object DataContext => View.DataContext;
    }
}