using System.Windows;
using Jamesnet.Wpf.Mvvm;
using Prism.Mvvm;

namespace Jamesnet.Wpf.Controls
{
    public class JamesWindow : Window, IViewable
    {
        public FrameworkElement View { get; init; }
        public ObservableBase ViewModel => View.DataContext is ObservableBase vm ? vm : null;

        public JamesWindow()
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
                frameworkElement.Loaded += JamesWindow_Loaded;
            }
        }

        private void JamesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is IViewLoadable vm)
            {
                fe.Loaded -= JamesWindow_Loaded;
                vm.OnLoaded(fe as IViewable);
            }
        }
    }
}
