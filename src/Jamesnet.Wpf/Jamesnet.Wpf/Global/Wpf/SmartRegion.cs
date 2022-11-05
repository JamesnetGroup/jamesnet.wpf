using System.Windows;
using System.Windows.Controls;

using Prism.Regions;

namespace Jamesnet.Wpf.Controls
{
    public class SmartRegion : ContentControl
    {
        public static readonly DependencyProperty ContentNameProperty = DependencyProperty.Register("ContentName", typeof(string), typeof(SmartRegion), new PropertyMetadata(ContentNamePropertyChanged));

        public string ContentName
        {
            get => (string)GetValue(ContentNameProperty);
            set => SetValue(ContentNameProperty, value);
        }

        private static void ContentNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string str && str != "")
            {
                IRegionManager rm = RegionManager.GetRegionManager(Application.Current.MainWindow);
                RegionManager.SetRegionName((SmartRegion)d, str);
                RegionManager.SetRegionManager(d, rm);
            }
        }

        public SmartRegion()
        {
        }
    }
}
