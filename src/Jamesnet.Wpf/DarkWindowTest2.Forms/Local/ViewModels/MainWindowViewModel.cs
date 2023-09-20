using Jamesnet.Wpf.Controls;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;

namespace DarkWindowTest2.Forms.Local.ViewModels;

public partial class MainWindowViewModel : IViewLoadable
{
    private readonly IRegionManager _regionManager;
    private readonly IContainerProvider _containerProvider;
    private readonly IEventAggregator _eh;

    public MainWindowViewModel(IRegionManager regionManager,
                            IContainerProvider containerProvider,
                            IEventAggregator eh)
    {
        _regionManager = regionManager;
        _containerProvider = containerProvider;
        _eh = eh;
    }

    public void OnLoaded(IViewable view)
    {
        IRegion mainRegion = _regionManager.Regions["MainRegion"];
        IViewable loginContent = _containerProvider.Resolve<IViewable> ("MainContent");

        if (!mainRegion.Views.Contains (loginContent))
        {
            mainRegion.Add (loginContent);
        }

        mainRegion.Activate (loginContent);
    }
}