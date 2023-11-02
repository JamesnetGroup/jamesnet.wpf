using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Mvvm;

namespace DarkWindowTest2.Forms.Local.ViewModels
{
    public partial class PopupContentViewModel : ObservableDialog
    {
        private readonly DimmingManager _dimmingManager;

        public PopupContentViewModel(DimmingManager dimmingManager)
        {
            _dimmingManager = dimmingManager;
        }

        public override void OnDialogClosed()
        {
            base.OnDialogClosed();
            _dimmingManager.Dimming(false);
        }
    }
}
