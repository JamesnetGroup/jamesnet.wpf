using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Jamesnet.Wpf.Controls
{
    public class JamesTreeViewItem : TreeViewItem
    {
        #region CornerRadius

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(JamesTreeViewItem),
                new FrameworkPropertyMetadata());

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        #endregion
    }
}
