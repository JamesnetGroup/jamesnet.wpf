using Jamesnet.Design.Geometry;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jamesnet.Wpf.Controls
{
    public enum IconType
    { 
        None,

        CheckDecagram,

        Email,
        EmailOutLine,

        Twitter,
    }

    public class JamesIcon : Label
    {
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(IconType), typeof(JamesIcon), new PropertyMetadata(IconType.None, IconPropertyChanged));
        public static DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(SolidColorBrush), typeof(JamesIcon), new PropertyMetadata(Brushes.Silver));
        public static DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(JamesIcon), new PropertyMetadata(null));

        public IconType Icon
        {
            get => (IconType)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public SolidColorBrush Fill
        {
            get => (SolidColorBrush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        private static void IconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            JamesIcon jamesIcon = (JamesIcon)d;
            string geometryData = "";

            switch (jamesIcon.Icon)
            {
                case IconType.Twitter: geometryData = GeometryData.Twitter; break;
                case IconType.CheckDecagram: geometryData = GeometryData.CheckDecagram; break;
                case IconType.Email: geometryData = GeometryData.Email; break;
                case IconType.EmailOutLine: geometryData = GeometryData.EmailOutLine; break;
            }

            jamesIcon.Data = Geometry.Parse(geometryData);
        }

        static JamesIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JamesIcon), new FrameworkPropertyMetadata(typeof(JamesIcon)));
        }
    }
}
