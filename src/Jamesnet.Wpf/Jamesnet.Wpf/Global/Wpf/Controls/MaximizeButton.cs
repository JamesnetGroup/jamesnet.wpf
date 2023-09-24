using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Controls
{
    public class MaximizeButton : Button
    {
        public bool IsMaximize
        {
            get { return (bool)GetValue (IsMaximizeProperty); }
            set { SetValue (IsMaximizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMaximize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMaximizeProperty =
            DependencyProperty.Register (nameof(IsMaximize), typeof(bool), typeof(MaximizeButton), new PropertyMetadata (false, MaximizePropertyChanged));

        private static void MaximizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var btn = (MaximizeButton)d;
            if (btn.IsMaximize)
                btn.img.Icon = btn.IsMaximize ? IconType.Restore : IconType.Maximize;
        }

        static MaximizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaximizeButton), new FrameworkPropertyMetadata(typeof(MaximizeButton)));
        }

        private JamesIcon img;
        public MaximizeButton()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate ();
            if (GetTemplateChild ("PART_IMG") is JamesIcon maxbtn)
            {
                img = maxbtn;
            }
        }
    }
}
