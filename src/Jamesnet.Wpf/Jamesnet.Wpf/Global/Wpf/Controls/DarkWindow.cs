using System.Windows;

namespace Jamesnet.Wpf.Controls;

public class DarkWindow : JamesWindow
{
    static DarkWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));
    }
}