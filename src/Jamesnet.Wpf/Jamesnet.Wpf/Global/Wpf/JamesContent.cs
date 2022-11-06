using System;
using System.Windows;
using System.Windows.Controls;

using Prism.Mvvm;

namespace Jamesnet.Wpf.Controls
{
    public class JamesContent : ContentControl, IViewable
    {
        public FrameworkElement View { get; init; }

        public JamesContent()
        {
            View = this;
            try
            {
                ViewModelLocationProvider.AutoWireViewModelChanged(this, AutoWireViewModelChanged);
            }
            catch (Exception ex)
            {

            }
        }

        private void AutoWireViewModelChanged(object view, object dataContext)
        {
            DataContext = dataContext;
            if (dataContext is IViewInitializable vm)
            {
                vm.OnViewWired(view as IViewable);
            }

            if (dataContext is IViewLoadable && view is FrameworkElement fe)
            {
                fe.Loaded += Fe_Loaded;
            }
        }

        private void Fe_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is IViewLoadable vm)
            {
                fe.Loaded -= Fe_Loaded;
                vm.OnLoaded(fe as IViewable);
            }
        }
    }
}