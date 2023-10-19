using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Mvvm;

namespace DarkWindowTest2.Forms.Local.ViewModels;

public partial class MainWindowViewModel : ObservableWindow, IViewLoadable
{
    private readonly ContentManager _contentManager;

    public MainWindowViewModel(ContentManager contentManager)
    {
        this._contentManager = contentManager;
    }

    public void OnLoaded(IViewable view)
    {
        this._contentManager.ActiveContent ("MainRegion", "MainContent");
    }
}