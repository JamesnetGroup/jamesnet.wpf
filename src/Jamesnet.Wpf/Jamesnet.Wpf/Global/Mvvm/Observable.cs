using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Event;
using Jamesnet.Wpf.Global.Event;
using Prism.Services.Dialogs;
using System;

namespace Jamesnet.Wpf.Mvvm;
public class ObservableBase : ObservableObject
{
    public ObservableBase() 
    {
        
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
        JamesApplication.GetService<IEventHub> ().Publish<PopupPubsub, bool> (false);
    }

    public virtual void OnDialogOpened(IDialogParameters parameters)
    {
        JamesApplication.GetService<IEventHub> ().Publish<PopupPubsub, bool> (true);
    }
}