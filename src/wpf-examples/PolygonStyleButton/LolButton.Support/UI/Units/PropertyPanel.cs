using System.Windows;
using System.Windows.Controls;

namespace LolButton.Support.UI.Units
{
    public class PropertyPanel : ContentControl
    {
        static PropertyPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyPanel), new FrameworkPropertyMetadata(typeof(PropertyPanel)));
        }
    }
}
