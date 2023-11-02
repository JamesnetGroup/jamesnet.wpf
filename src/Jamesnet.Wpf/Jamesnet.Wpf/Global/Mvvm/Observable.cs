using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Global.Composition;
using Prism.Services.Dialogs;
using System;
using System.Reflection;

namespace Jamesnet.Wpf.Mvvm
{
    public class ObservableBase : ObservableObject
    {

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
            var useDimmingAttribute = GetType().GetCustomAttribute<UseDimmingAttribute>();
            if (useDimmingAttribute != null && useDimmingAttribute.UseDimming)
            {
                _dimmingManager.Dimming(false);
            }
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            var useDimmingAttribute = GetType().GetCustomAttribute<UseDimmingAttribute>();
            if (useDimmingAttribute != null && useDimmingAttribute.UseDimming)
            {
                _dimmingManager.Dimming(true);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class UseDimmingAttribute : Attribute
    {
        public bool UseDimming { get; private set; }

        public UseDimmingAttribute()
        {
            UseDimming = true;
        }

        public UseDimmingAttribute(bool useDimming)
        {
            UseDimming = useDimming;
        }
    }
}
