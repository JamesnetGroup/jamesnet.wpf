using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using ViewModelSample.Core.Names;
using ViewModelSample.Forms.UI.Units;

namespace ViewModelSample.Settings
{
        internal class ViewModules : IModule
        {
                public void OnInitialized(IContainerProvider containerProvider)
                {

                }

                public void RegisterTypes(IContainerRegistry containerRegistry)
                {
                        containerRegistry.RegisterSingleton<IViewable, MainContent>(ContentNameManager.Main);
                }
        }
}
