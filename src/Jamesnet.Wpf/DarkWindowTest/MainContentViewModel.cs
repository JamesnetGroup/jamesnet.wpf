using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Mvvm;

namespace DarkWindowTest
{
    public partial class MainContentViewModel : ObservableBase, IViewLoadable
    {
        private ContentManager _contentManager;
        public MainContentViewModel() 
        {
        }

        public void OnLoaded(IViewable view)
        {
        }
    }
}
