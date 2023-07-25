using System.Windows;
using System.Windows.Controls;
using System.Linq;
namespace Jamesnet.Wpf.Controls
{
    public enum JustifyEnum
    {
        SpaceBase,
        SpaceAround,
        SpaceBetween
    }
    public class JamesPanel : StackPanel
    {
        public double Spacing
        {
            get { return (double)GetValue (SpacingProperty); }
            set { SetValue (SpacingProperty, value); }
        }

        public static readonly DependencyProperty SpacingProperty =
            DependencyProperty.Register ("Spacing", typeof (double), typeof (JamesPanel), new PropertyMetadata (0.0));



        public JustifyEnum Justify
        {
            get { return (JustifyEnum)GetValue (JustifyProperty); }
            set { SetValue (JustifyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Justify.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JustifyProperty =
            DependencyProperty.Register ("Justify", typeof (JustifyEnum), typeof (JamesPanel), new PropertyMetadata (JustifyEnum.SpaceBase));



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged (e);

            if (IsJustifyUseOption ())
            {
                justifyLayout ();
                return;
            }
            PerformLayout ();
        }
        private bool IsJustifyUseOption()
        {
            if (Justify == JustifyEnum.SpaceBase)
            {
                return false;
            }
            return true;
        }
        private void justifyLayout()
        {

            foreach (UIElement child in base.Children)
            {
            }
        }
        private void PerformLayout()
        {
            if (Spacing < 0)
                return;
            if (base.Children.Count <= 1)
                return;

            Thickness thick = Orientation == Orientation.Horizontal ? new Thickness (0, 0, Spacing, 0) : new Thickness (0, 0, 0, Spacing);

            int lastIdx = base.Children.Count - 1;
            int idx = 0;
            foreach (UIElement child in base.Children)
            {
                if (lastIdx == idx)
                    break;
                child.SetValue (MarginProperty, thick);
                idx++;
            }
        }
    }
}
