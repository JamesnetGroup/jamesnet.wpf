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
                fe.Loaded += (s1, e1) =>
                {
                    if (s1 is FrameworkElement fe && fe.DataContext is IViewLoadable vm)
                    {
                        vm.OnLoaded(view as IViewable);
                    }
                };
            }
        }
    }
}