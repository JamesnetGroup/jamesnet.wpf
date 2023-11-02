using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Event;
using Jamesnet.Wpf.Global.Composition;
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
            get => _dimming;
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
        private readonly DimmingManager _dimmingManager;

        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public ObservableDialog()
        {
            _dimmingManager = new DimmingManager();
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
            _dimmingManager.Dimming(false);
            //JamesApplication.GetService<IEventHub> ().Publish<JamesPopupEvent, bool> (false);
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            _dimmingManager.Dimming(true);
            //JamesApplication.GetService<IEventHub> ().Publish<JamesPopupEvent, bool> (true);
        }
    }
}
