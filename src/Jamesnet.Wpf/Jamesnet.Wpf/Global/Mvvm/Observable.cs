using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Regions;
using System;

namespace Jamesnet.Wpf.Mvvm
{
        [INotifyPropertyChanged]
        public partial class ObservableBase : IViewLoadable
        {
                protected readonly IRegionManager _regionManager;
                protected readonly IContainerProvider _containerProvider;

                public ObservableBase(IRegionManager regionManager, IContainerProvider containerProvider)
                {
                        this._regionManager = regionManager;
                        this._containerProvider = containerProvider;
                }
                public virtual void OnLoaded(IViewable smartWindow)
                {
                        Console.WriteLine("");
                }
        }
}
