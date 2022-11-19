using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace Jamesnet.Wpf.Controls
{
    public class JamesRegion : ContentControl
    {
        public static readonly DependencyProperty RegionNameProperty = DependencyProperty.Register("RegionName", typeof(string), typeof(JamesRegion), new PropertyMetadata(ContentNamePropertyChanged));

        public string RegionName
        {
            get => (string)GetValue(RegionNameProperty);
            set => SetValue(RegionNameProperty, value);
        }

        private static void ContentNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string str && str != "")
            {
                IRegionManager rm = RegionManager.GetRegionManager(Application.Current.MainWindow);
                RegionManager.SetRegionName((JamesRegion)d, str);
                RegionManager.SetRegionManager(d, rm);
            }
        }
        static JamesRegion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JamesRegion), new FrameworkPropertyMetadata(typeof(JamesRegion)));
        }

        public JamesRegion()
        {
        }
    }
}
