using Jamesnet.Wpf.Controls;
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace Jamesnet.Wpf.Global.Composition
{
    internal class AutoWireManager
    {
        private FrameworkElement _view;


        internal void InitializeAutoWire(FrameworkElement view)
        {
            _view = view;
            ViewModelLocationProvider.AutoWireViewModelChanged(view, AutoWireViewModelChanged);
        }

        public virtual void AutoWireViewModelChanged(object view, object dataContext)
        {
            _view.DataContext = dataContext;

            if (dataContext is IViewInitializable viewModel)
            {
                viewModel.OnViewWired(view as IViewable);
            }

            if (dataContext is IViewLoadable && view is FrameworkElement frameworkElement)
            {
                frameworkElement.Loaded += JamesContent_Loaded;
            }
        }

        private void JamesContent_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is IViewLoadable vm)
            {
                fe.Loaded -= JamesContent_Loaded;
                vm.OnLoaded(fe as IViewable);
            }
        }

        internal FrameworkElement GetView()
        {
            return _view;
        }

        internal INotifyPropertyChanged GetDataContext()
        {
            return _view.DataContext is INotifyPropertyChanged vm ? vm : null;
        }
    }
}
