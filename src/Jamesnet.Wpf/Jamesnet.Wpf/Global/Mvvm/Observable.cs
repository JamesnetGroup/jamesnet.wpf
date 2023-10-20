using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Event;
using Jamesnet.Wpf.Global.Event;
using Prism.Services.Dialogs;
using System;

namespace Jamesnet.Wpf.Mvvm
{
    public class ObservableBase : ObservableObject
    {

    }

    public partial class ObservableWindow : ObservableBase
    {
        private bool _dimming = false;

        public bool Dimming
        {
            get => _dimming = false;
            set => SetProperty (ref _dimming, value);
        }

        public ObservableWindow()
        {
            JamesApplication.GetService<IEventHub> ().Subscribe<JamesPopupEvent, bool> (e =>
            {
                this.Dimming = e;
            });
        }
    }

    public class ObservableDialog : ObservableObject, IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
            JamesApplication.GetService<IEventHub> ().Publish<JamesPopupEvent, bool> (false);
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            JamesApplication.GetService<IEventHub> ().Publish<JamesPopupEvent, bool> (true);
        }
    }
}
