using DarkWindowTest2.Forms.Local.ViewModels;
using DarkWindowTest2.Forms.UI.Views;
using Jamesnet.Wpf.Global.Location;

namespace DarkWindowTest3.Properties;
public class WireDataContext : ViewModelLocationScenario
{
    protected override void Match(ViewModelLocatorCollection items)
    {
        items.Register<MainWindow, MainWindowViewModel>();
    }
}