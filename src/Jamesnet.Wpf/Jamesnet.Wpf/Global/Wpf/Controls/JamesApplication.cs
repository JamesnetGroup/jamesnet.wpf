using Jamesnet.Wpf.Composition;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Global.Event;
using Jamesnet.Wpf.Global.Location;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace Jamesnet.Wpf.Controls;

public abstract class JamesApplication : PrismApplication
{
    private List<IModule> _modules = new ();
    private object theme;

    public JamesApplication()
    {

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        ViewModelLocatorCollection items = new ();
        RegisterWireDataContexts (items);

        base.OnStartup (e);
    }

    public JamesApplication AddInversionModule<T>() where T : IModule, new()
    {
        IModule module = new T ();
        _modules.Add (module);

        return this;
    }

    public JamesApplication AddWireDataContext<T>() where T : ViewModelLocationScenario, new()
    {
        ViewModelLocationScenario scenario = new T ();
        _ = scenario.Publish ();

        return this;
    }

    protected virtual void RegisterWireDataContexts(ViewModelLocatorCollection items)
    {
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance (this);
        containerRegistry.RegisterSingleton<ContentManager> ();
        containerRegistry.RegisterSingleton<IEventHub, EventAggregatorHub> ();

        if (theme != null)
        {
            containerRegistry.RegisterInstance (theme as ResourceInitializer);
            containerRegistry.RegisterSingleton<ResourceManager> ();
            ResourceManager themeManager = GetService<ResourceManager> ();
        }

        foreach (IModule module in _modules)
        {
            module.RegisterTypes (containerRegistry);
        }
    }

    public JamesApplication InitializeTheme<T>() where T : ResourceInitializer, new()
    {
        theme = new T ();
        return this;
    }

    public static T GetService<T>()
    {
        if (JamesApplication.Current is JamesApplication app)
        {
            return app.Container.Resolve<T> ();
        }
        return default;
    }

    public static ResourceDictionary Resource()
    {
        if (JamesApplication.Current is JamesApplication app)
        {
            return app.Resources;
        }
        return default;
    }
}