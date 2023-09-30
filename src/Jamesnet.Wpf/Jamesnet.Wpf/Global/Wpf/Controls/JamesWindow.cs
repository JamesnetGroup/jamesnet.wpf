using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Jamesnet.Wpf.Global.Composition;

namespace Jamesnet.Wpf.Controls
{
    public abstract class JamesWindow : Window, IViewable
    {
        private readonly AutoWireManager _autoWireManager;

        public FrameworkElement View => _autoWireManager.GetView();
        public INotifyPropertyChanged ViewModel => _autoWireManager.GetDataContext();

        public JamesWindow()
        {
            _autoWireManager = new AutoWireManager();
            _autoWireManager.InitializeAutoWire(this);
        }

        public JamesWindow AddChild(FrameworkElement fe)
        {
            Content = fe;
            return this;
        }

        public JamesWindow CenterAlignContent()
        {
            if (Content is FrameworkElement content)
            {
                content.HorizontalAlignment = HorizontalAlignment.Center;
                content.VerticalAlignment = VerticalAlignment.Center;
            }
            return this;
        }

        public JamesWindow ApplyThemeColors(string background, string borderBrush, string foreground)
        {
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(background));
            BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(borderBrush));
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(foreground));
            return this;
        }
    }
}
