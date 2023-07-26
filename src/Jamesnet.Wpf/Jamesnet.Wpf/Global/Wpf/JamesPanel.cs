using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jamesnet.Wpf.Controls
{
    public enum JustifyEnum
    {
        None,
        SpaceAround,
        SpaceBetween,
        SpaceEvenly
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
            DependencyProperty.Register ("Justify", typeof (JustifyEnum), typeof (JamesPanel), new PropertyMetadata (JustifyEnum.None));

        protected override Size MeasureOverride(Size constraint)
        {
            if (IsJustifyUseOption ())
            {
                justifyLayout ();
                return base.MeasureOverride (constraint);
            }
            PerformLayout ();
            return base.MeasureOverride (constraint);
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged (e);

            string propertyName = e.Property.Name;
            if (propertyName == nameof (Spacing) || propertyName == nameof (Justify))
            {
                if (IsJustifyUseOption ())
                {
                    justifyLayout ();
                    return;
                }
                PerformLayout ();
            }
        }
        private bool IsJustifyUseOption()
        {
            if (IsNan(this.ActualWidth) || IsNan (this.ActualHeight))
                return false;
            if (Justify == JustifyEnum.None)
                return false;

            return true;
        }
        private bool IsNan(double value)
        {
            if(double.IsInfinity(value)) return true;
            if(double.IsNaN (value)) return true;

            return false;
        }
        private void justifyLayout()
        {
            double allChildSize = 0;
            foreach (UIElement child in base.Children)
            {
                allChildSize += (Orientation == Orientation.Horizontal ? (double)child.GetValue (WidthProperty) : (double)child.GetValue (HeightProperty));
            }
            if (allChildSize == 0)
                return;
            if (Width == 0 && Orientation == Orientation.Horizontal)
                return;
            if(Height == 0 && Orientation == Orientation.Vertical) 
                return;

            var parent = VisualTreeHelper.GetParent (this) as ContentPresenter;
            var parentSize = (Orientation == Orientation.Horizontal ? (double)parent.ActualWidth : (double)parent.ActualHeight);
            if (Justify == JustifyEnum.SpaceAround)
            {
                double aroundMargin = (parentSize - (double)allChildSize) / ((double)(base.Children.Count * 2) );
                Debug.WriteLine ($"Width {this.Width}");
                Debug.WriteLine ($"allChildSize {allChildSize}");
                Debug.WriteLine ($"Width - allChilSize {aroundMargin}");
                foreach (UIElement child in base.Children)
                {
                    Thickness thick = Orientation == Orientation.Horizontal ? new Thickness (Math.Truncate (aroundMargin), 0, Math.Truncate (aroundMargin), 0) : new Thickness (0, Math.Truncate (aroundMargin), 0, Math.Truncate (aroundMargin));
                    child.SetValue (MarginProperty, thick);
                }
            }
            else if(Justify == JustifyEnum.SpaceBetween)
            {
                double aroundMargin = (parentSize - (double)allChildSize) / (double)(base.Children.Count - 1);

                int lastIdx = base.Children.Count - 1;
                int idx = 0;
                foreach (UIElement child in base.Children)
                {
                    child.SetValue (MarginProperty, new Thickness (0, 0, 0, 0));
                    if (lastIdx == idx)
                        break;
                    Thickness thick = Orientation == Orientation.Horizontal ? new Thickness (0, 0, aroundMargin, 0) : new Thickness (0, 0, 0, aroundMargin);
                    child.SetValue (MarginProperty, thick);

                    idx++;
                }
            }
            else if(Justify == JustifyEnum.SpaceEvenly)
            {
                double aroundMargin = (parentSize - (double)allChildSize) / (double)(base.Children.Count + 1);

                int lastIdx = base.Children.Count - 1;
                int idx = 0;
                foreach (UIElement child in base.Children)
                {
                    child.SetValue (MarginProperty, new Thickness (0, 0, 0, 0));
                    Thickness thick = Orientation == Orientation.Horizontal ? new Thickness (aroundMargin, 0, 0, 0) : new Thickness (0, aroundMargin, 0, 0);
     
                    child.SetValue (MarginProperty, thick);

                    idx++;
                }
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
                child.SetValue (MarginProperty, new Thickness (0, 0, 0, 0));
                if (lastIdx == idx)
                    break;
                child.SetValue (MarginProperty, thick);
                idx++;
            }
        }
    }
}
