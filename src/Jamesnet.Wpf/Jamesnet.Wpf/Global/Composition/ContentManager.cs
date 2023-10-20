using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Regions;

namespace Jamesnet.Wpf.Global.Composition
{

    public class ContentManager
    {
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        public ContentManager(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
        }

        public void ActiveContent(string regionName, string contentName)
        {
            ActiveContent<IViewable> (regionName, contentName);
        }

        public void ActiveContent<T>(string regionName, string contentName)
        {
            IRegion region = _regionManager.Regions[regionName];
            T content = _containerProvider.Resolve<T> (contentName);

            if (!region.Views.Contains (content))
            {
                region.Add (content);
            }
            region.Activate (content);
        }

        public void DeactiveContent(string regionName, string contentName)
        {
            DeactiveContent<IViewable> (regionName, contentName);
        }

        public void DeactiveContent<T>(string regionName, string contentName)
        {
            IRegion region = _regionManager.Regions[regionName];
            T content = _containerProvider.Resolve<T> (contentName);

            if (region.Views.Contains (content))
            {
                region.Deactivate (content);
            }
        }
    }
}
