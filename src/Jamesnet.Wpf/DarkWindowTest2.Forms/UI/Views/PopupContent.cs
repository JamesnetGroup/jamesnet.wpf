using Jamesnet.Wpf.Controls;
using System.Windows;

namespace DarkWindowTest2.Forms.UI.Views;

public class PopupContent :JamesContent
{
    static PopupContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata (typeof (PopupContent), new FrameworkPropertyMetadata (typeof (PopupContent)));
    }
}
