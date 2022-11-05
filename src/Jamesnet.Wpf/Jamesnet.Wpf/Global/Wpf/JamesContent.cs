using System;
using System.Windows;
using System.Windows.Controls;

using Prism.Mvvm;

namespace Jamesnet.Wpf.Controls
{
    public class JamesContent : ContentControl, IViewable
    {
        public static readonly DependencyProperty ContentNameProperty = DependencyProperty.Register("ContentName", typeof(string), typeof(SmartRegion), new PropertyMetadata());
        public string ContentName
        {
            get => (string)GetValue(ContentNameProperty);
            set => SetValue(ContentNameProperty, value);
        }

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

            Loaded += SmartWindow_Loaded;
        }

        private void SmartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IViewLoadable vm)
            {
                vm.OnLoaded(this as IViewable);
            }
        }

        private void AutoWireViewModelChanged(object view, object dataContext)
        {
            DataContext = dataContext;
            if (dataContext is IViewInitializable vm)
            {
                vm.OnViewWired(view as IViewable);
            }
        }
    }
}