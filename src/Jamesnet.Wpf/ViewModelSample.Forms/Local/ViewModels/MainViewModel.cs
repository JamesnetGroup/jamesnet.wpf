using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;
using ViewModelSample.Core.Names;

namespace ViewModelSample.Forms.Local.ViewModels
{
        public partial class MainViewModel : ObservableBase
        {

                [ObservableProperty]
                private string _name;

                public MainViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
                        : base(regionManager, containerProvider)
                {

                }

                public override void OnLoaded(IViewable smartWindow)
                {
                        base.OnLoaded(smartWindow);

                        IRegion mainRegion = _regionManager.Regions[RegionNameManager.MainRegion];
                        IViewable loginContent = _containerProvider.Resolve<IViewable>(ContentNameManager. Main);

                        if (!mainRegion.Views.Contains(loginContent))
                        {
                                mainRegion.Add(loginContent);
                        }
                        mainRegion.Activate(loginContent);

                        this.Name = "ViewModel 확장편입니당";
                }
        }
}
