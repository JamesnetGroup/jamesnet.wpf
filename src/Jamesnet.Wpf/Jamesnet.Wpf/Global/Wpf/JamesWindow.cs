using System.Windows;

using Prism.Mvvm;

namespace Jamesnet.Wpf.Controls
{
    public class JamesWindow : Window, IViewable
    {
        public FrameworkElement View { get; init; }

        public JamesWindow()
        {
            View = this;
            ViewModelLocationProvider.AutoWireViewModelChanged(this, Callback);
            Loaded += SmartWindow_Loaded;
        }

        private void SmartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IViewLoadable vm)
            {
                vm.OnLoaded(this as IViewable);
            }
        }

        private void Callback(object view, object dataContext)
        {
            if (dataContext is IViewInitializable vm)
            {
                vm.OnViewWired(this as IViewable);
            }
        }
    }
}
