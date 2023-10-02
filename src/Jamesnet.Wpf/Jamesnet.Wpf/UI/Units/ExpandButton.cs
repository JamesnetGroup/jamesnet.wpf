using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Jamesnet.Wpf.UI.Units
{
    public class ExpandButton : ToggleButton
    {
        static ExpandButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpandButton), new FrameworkPropertyMetadata(typeof(ExpandButton)));
        }
    }
}
