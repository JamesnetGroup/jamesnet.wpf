using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Controls
{
    public class CloseButton : Button
    {
        static CloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata (typeof (CloseButton), new FrameworkPropertyMetadata (typeof (CloseButton)));
        }
    }

}
