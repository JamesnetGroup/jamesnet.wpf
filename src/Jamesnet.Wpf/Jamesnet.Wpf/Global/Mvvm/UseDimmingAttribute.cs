using System;

namespace Jamesnet.Wpf.Mvvm
{
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
