using Jamesnet.Wpf.Global.Location;
using Jamesnet.Wpf.Global.Evemt;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Collections.Generic;
using Unity;
using System.Windows;
using System.Windows.Controls;
using Jamesnet.Wpf.Local.Helpers;
using Prism.Mvvm;
using Jamesnet.Wpf.Local.ViewModels;
using Jamesnet.Wpf.Local.Models;
using Jamesnet.Wpf.UI.Units;

namespace Jamesnet.Wpf.Controls
{
    public abstract class AnatomyApplication : JamesApplication
    {
        AnatomyCollection _items;
        private AnatomyAnalyzer _window;

        protected override Window CreateShell()
        {
            _window = new AnatomyAnalyzer();

            return _window;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _items = new();
            RegisterControls(_items);

            var service = GetService<AnatomyService>();

            service.Add(_items);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);

            containerRegistry.RegisterSingleton<AnatomyService>();
            ViewModelLocationProvider.Register<AnatomyAnalyzer, AnatomyAnalyzerViewModel>();
            ViewModelLocationProvider.Register<AnatomyPreview, AnatomyContentViewModel>();
        }

        protected virtual void RegisterControls(AnatomyCollection items)
        {

        }
    }
}
