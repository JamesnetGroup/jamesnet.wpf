using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Jamesnet.Wpf.Controls
{
    public class JamesTreeView : TreeView
    {
        #region CornerRadius

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(JamesTreeView),
                new FrameworkPropertyMetadata());

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        #endregion
    }
}
