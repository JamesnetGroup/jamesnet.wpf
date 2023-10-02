using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Local.Helpers;
using Jamesnet.Wpf.Local.Models;
using Jamesnet.Wpf.Mvvm;
using Jamesnet.Wpf.UI.Units;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Jamesnet.Wpf.Local.ViewModels
{
    internal partial class AnatomyAnalyzerViewModel : ObservableBase, IViewLoadable
    {
        private readonly AnatomyService _anatomyService;
        private readonly IContainerRegistry _containerRegistry;
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        public Dictionary<Type, object> Instances { get; set; }

        public ObservableCollection<AnatomyItem> Controls { get; set; }

        public AnatomyAnalyzerViewModel(AnatomyService anatomyService, IContainerProvider containerProvider, IRegionManager regionManager) 
        {
            Instances = new();
            Controls = new();
            _anatomyService = anatomyService;
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            _anatomyService.AnatomyControlChanged += _anatomyService_AnatomyControlChanged;
        }

        public void OnLoaded(IViewable view)
        {

        }

        private void _anatomyService_AnatomyControlChanged(object sender, AnatomyControlChangedEventArgs e)
        {
            foreach (Type item in e.Controls)
            {
                if (item.IsSubclassOf(typeof(Control)))
                {
                    //Control control = (Control)Activator.CreateInstance(item);
                    //Instance.Children.Add(control);

                    AnatomyItem anatomyItem = new();
                    anatomyItem.Name = item.Name;
                    anatomyItem.Type = item;
                    anatomyItem.IconType = IconType.ButtonCursor;
                    Controls.Add(anatomyItem);
                }
            }
        }

        [RelayCommand]
        private void TreeItemSelected(AnatomyItem item)
        {
            ImportContent("AnatomyObjectRegion", item);
        }

        private void ImportContent(string regionName, AnatomyItem item)
        {
            IRegion region = _regionManager.Regions[regionName];
            object content = GetControl(item);

            if (!region.Views.Contains(content))
            {
                region.Add(content);
            }
            region.Activate(content);
        }

        private object GetControl(AnatomyItem item)
        {
            if (!Instances.ContainsKey(item.Type))
            {
                Control control = (Control)Activator.CreateInstance(item.Type);
                AnatomyPreview preview = new();
                preview.Content = control;
                preview.DataContext = item;
                Instances.Add(item.Type, preview);
            }
            return Instances[item.Type];
        }
    }
}
