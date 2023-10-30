using Jamesnet.Wpf.Composition;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Global.Event;
using Jamesnet.Wpf.Global.Location;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Unity;

namespace Jamesnet.Wpf.Controls
{
    public abstract class JamesApplication : PrismApplication
    {
        private List<IModule> _modules = new List<IModule> ();
        private object theme;

        public JamesApplication()
        {
            try
            {
                AddDefaultThemeResource();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while adding default theme resource: {ex.Message}");
                throw;
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModelLocatorCollection items = new ViewModelLocatorCollection ();
            RegisterWireDataContexts (items);

            base.OnStartup (e);
        }

        private void AddDefaultThemeResource()
        {
            // 실행 중인 응용 프로그램의 주 어셈블리를 가져옵니다.
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null)
            {
                Console.WriteLine("Error: Could not get the entry assembly.");
                return;
            }

            AssemblyName[] referencedAssemblies = entryAssembly.GetReferencedAssemblies();
            foreach (AssemblyName assemblyName in referencedAssemblies)
            {
                try
                {
                    var resourceName = assemblyName.Name + ";component/Themes/Default.xaml";
                    var resourceUri = new Uri("/" + resourceName, UriKind.RelativeOrAbsolute);

                    ResourceDictionary resourceDictionary = new ResourceDictionary
                    {
                        Source = resourceUri
                    };

                    this.Resources.MergedDictionaries.Add(resourceDictionary);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not load Themes/Default.xaml from {assemblyName.Name}: {ex.Message}");
                }
            }

            Console.WriteLine("Error: Could not find Themes/Default.xaml resource in any referenced assembly.");
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
                containerRegistry.RegisterInstance(theme as BaseResourceInitializer);
                containerRegistry.RegisterSingleton<ResourceManager>();
                ResourceManager themeManager = GetService<ResourceManager>();
            }

            foreach (IModule module in _modules)
            {
                module.RegisterTypes (containerRegistry);
            }
        }

        public JamesApplication InitializeResource<T>() where T : BaseResourceInitializer, new()
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
}
