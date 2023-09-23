using System.ComponentModel;
using System.Windows;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Mvvm;
using Prism.Mvvm;

namespace Jamesnet.Wpf.Controls
{
    public class JamesWindow : Window, IViewable
    {
        private readonly AutoWireManager _autoWireManager;

        public FrameworkElement View => _autoWireManager.GetView();
        public INotifyPropertyChanged ViewModel => _autoWireManager.GetDataContext();

        public JamesWindow()
        {
            _autoWireManager = new AutoWireManager();
            _autoWireManager.InitializeAutoWire(this);
        }
    }
}
