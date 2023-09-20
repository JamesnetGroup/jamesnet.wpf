using DarkWindowTest2.Forms.UI.Views;
using Jamesnet.Wpf.Controls;
using System.Windows;

namespace DarkWindowTest3;

public class App :JamesApplication
{
    protected override Window CreateShell()
    {
        return new MainWindow ();
    }
}