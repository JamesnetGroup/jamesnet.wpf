using Jamesnet.Wpf.Global.Location;
using Jamesnet.Wpf.Global.Evemt;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Collections.Generic;
using Unity;
using Jamesnet.Wpf.Models;
using Jamesnet.Wpf.Composition;
using System;
using Jamesnet.Wpf.Global.Extensions;
using Jamesnet.Wpf.Global.Composition;
using System.Windows;

namespace Jamesnet.Wpf.Controls
{
    public abstract class JamesApplication : PrismApplication
    {
        private List<IModule> _modules = new();
        private object theme;

        public JamesApplication()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
        }

        public JamesApplication AddInversionModule<T>() where T : IModule, new()
        {
            IModule module = new T();
            _modules.Add(module);

            return this;
        }

        public JamesApplication AddWireDataContext<T>() where T : ViewModelLocationScenario, new()
        {
            ViewModelLocationScenario scenario = new T();
            _ = scenario.Publish();

            return this;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(this);            
            containerRegistry.RegisterSingleton<IEventHub, EventAggregatorHub>();

            if (theme != null)
            {
                containerRegistry.RegisterInstance(theme as ResourceInitializer);
                containerRegistry.RegisterSingleton<ResourceManager>();
                ResourceManager themeManager = GetService<ResourceManager>();
            }

            foreach (IModule module in _modules)
            {
                module.RegisterTypes(containerRegistry);
            }
        }

        public JamesApplication InitializeTheme<T>() where T : ResourceInitializer, new()
        {
            theme = new T();
            return this;
        }

        public static T GetService<T>()
        {
            if (JamesApplication.Current is JamesApplication app)
            {
                return app.Container.Resolve<T>();
            }
            return default;
        }
    }
}
