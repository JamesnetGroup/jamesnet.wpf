using System.Windows;
using Jamesnet.Wpf.Controls;

namespace DarkWindowTest2.Forms.UI.Views;

public class MainContent :JamesContent
{
    static MainContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MainContent), new FrameworkPropertyMetadata(typeof(MainContent)));
    }
}