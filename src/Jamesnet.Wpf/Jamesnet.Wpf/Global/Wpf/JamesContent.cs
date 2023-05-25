using System;
using System.Windows;
using System.Windows.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Mvvm;

namespace Jamesnet.Wpf.Controls
{
    public class JamesContent : ContentControl, IViewable
    {
        public FrameworkElement View { get; init; }
        public ObservableBase ViewModel => View.DataContext is ObservableBase vm ? vm : null;

        public JamesContent()
        {
            View = this;
            ViewModelLocationProvider.AutoWireViewModelChanged(this, AutoWireViewModelChanged);
        }

        private void AutoWireViewModelChanged(object view, object dataContext)
        {
            DataContext = dataContext;

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
    }
}