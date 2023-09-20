using DarkWindowTest2.Forms.UI.Views;
using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;

namespace DarkWindowTest3.Properties;

public class ViewModules : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IViewable, MainContent>("MainContent");
    }
}