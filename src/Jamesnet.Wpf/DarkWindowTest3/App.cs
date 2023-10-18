using DarkWindowTest2.Forms.Local.ViewModels;
using DarkWindowTest2.Forms.UI.Views;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Location;
using Prism.Ioc;
using System.Windows;

namespace DarkWindowTest3;

public class App :JamesApplication
{
    protected override Window CreateShell()
    {
        return new MainWindow ();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes (containerRegistry);

        containerRegistry.RegisterSingleton<IViewable, MainContent> ("MainContent");
        containerRegistry.RegisterDialog<PopupContent, PopupContentViewModel> ();
    }

    protected override void RegisterWireDataContexts(ViewModelLocatorCollection items)
    {
        base.RegisterWireDataContexts (items);

        items.Register<MainWindow, MainWindowViewModel> ();
        items.Register<MainContent, MainContentViewModel> ();
    }
}