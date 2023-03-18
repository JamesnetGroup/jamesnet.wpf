using Jamesnet.Wpf.Global.Location;
using ViewModelSample.Forms.Local.ViewModels;
using ViewModelSample.Forms.UI.Views;

namespace ViewModelSample.Settings
{
        internal class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<MainWindow, MainViewModel>();
        }
    }
}
