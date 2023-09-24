using Jamesnet.Wpf.Global.Location;
using Jamesnet.Wpf.Global.Evemt;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Collections.Generic;
using Unity;

namespace Jamesnet.Wpf.Controls
{
    public abstract class JamesApplication : PrismApplication
    {
        private List<IModule> _modules = new();

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
            containerRegistry.RegisterSingleton<IEventHub, EventAggregatorHub>();

            foreach (IModule module in _modules)
            {
                module.RegisterTypes(containerRegistry);
            }
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
