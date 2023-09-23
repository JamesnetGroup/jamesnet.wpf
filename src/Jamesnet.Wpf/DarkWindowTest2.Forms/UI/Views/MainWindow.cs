using System.Windows;
using Jamesnet.Wpf.Controls;

namespace DarkWindowTest2.Forms.UI.Views;

public class MainWindow : DarkThemeWindow
{
    static MainWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata (typeof (MainWindow), new FrameworkPropertyMetadata (typeof (MainWindow)));
    }
}
