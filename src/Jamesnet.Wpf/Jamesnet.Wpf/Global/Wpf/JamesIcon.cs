using Jamesnet.Design.Geometry;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using YamlDotNet.Core;

namespace Jamesnet.Wpf.Controls
{
    public enum IconType
    { 
        None, 
        AccountMultipleOutline,
        Apple,
        BellOutline,
        CardMultiple,
        CardMultipleOutline,
        CheckDecagram,
        Comment,
        CommentOutline,
        Domain,
        DotsHorizontal,
        Email,
        EmailOutLine,
        Facebook,
        Google,
        Heart,
        HeartOutline,
        Image,
        Instagram,
        Link,
        LinkBox,
        Linkedin,
        LinkVariant,
        MapMaker,
        MapMarkerOutline,
        Microsoft,
        Netflix,
        Pin,
        Star,
        Twitter,
        Youtube,
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
                case IconType.Apple: geometryData = GeometryData.Apple; break;
                case IconType.AccountMultipleOutline: geometryData = GeometryData.AccountMultipleOutline; break;
                case IconType.BellOutline: geometryData = GeometryData.BellOutline; break;
                case IconType.CardMultiple: geometryData = GeometryData.CardMultiple; break;
                case IconType.CardMultipleOutline: geometryData = GeometryData.CardMultipleOutline; break;
                case IconType.CheckDecagram: geometryData = GeometryData.CheckDecagram; break;
                case IconType.Comment: geometryData = GeometryData.Comment; break;
                case IconType.CommentOutline: geometryData = GeometryData.CommentOutline; break;
                case IconType.Domain: geometryData = GeometryData.Domain; break;
                case IconType.DotsHorizontal: geometryData = GeometryData.DotsHorizontal; break;
                case IconType.Email: geometryData = GeometryData.Email; break;
                case IconType.EmailOutLine: geometryData = GeometryData.EmailOutLine; break;
                case IconType.Facebook: geometryData = GeometryData.Facebook; break;
                case IconType.Google: geometryData = GeometryData.Google; break;
                case IconType.Heart: geometryData = GeometryData.Heart; break;
                case IconType.HeartOutline: geometryData = GeometryData.HeartOutline; break;
                case IconType.Image: geometryData = GeometryData.Image; break;
                case IconType.Instagram: geometryData = GeometryData.Instagram; break;
                case IconType.Link: geometryData = GeometryData.Link; break;
                case IconType.LinkBox: geometryData = GeometryData.LinkBox; break;
                case IconType.Linkedin: geometryData = GeometryData.Linkedin; break;
                case IconType.LinkVariant: geometryData = GeometryData.LinkVariant; break;
                case IconType.MapMaker: geometryData = GeometryData.MapMaker; break;
                case IconType.MapMarkerOutline: geometryData = GeometryData.MapMarkerOutline; break;
                case IconType.Microsoft: geometryData = GeometryData.Microsoft; break;
                case IconType.Netflix: geometryData = GeometryData.Netflix; break;
                case IconType.Pin: geometryData = GeometryData.Pin; break;
                case IconType.Star: geometryData = GeometryData.Star; break;
                case IconType.Twitter: geometryData = GeometryData.Twitter; break;
                case IconType.Youtube: geometryData = GeometryData.Youtube; break;
            }

            jamesIcon.Data = Geometry.Parse(geometryData);
        }

        static JamesIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JamesIcon), new FrameworkPropertyMetadata(typeof(JamesIcon)));
        }
    }
}
