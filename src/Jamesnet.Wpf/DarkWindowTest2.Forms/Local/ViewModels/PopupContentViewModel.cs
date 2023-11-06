using Jamesnet.Wpf.Mvvm;
using Prism.Services.Dialogs;

namespace DarkWindowTest2.Forms.Local.ViewModels
{
    [UseDimming]
    public partial class PopupContentViewModel : ObservableDialog
    {
        public virtual void OnDialogClosed()
        {
            base.OnDialogClosed();
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
        }
    }
}
