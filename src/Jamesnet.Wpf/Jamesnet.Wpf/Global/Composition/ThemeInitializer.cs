using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamesnet.Wpf.Global.Composition
{
    public abstract class ThemeInitializer
    {
        public string Resource { get; }
        public string DefaultTheme { get; }

        protected abstract string InitializeResource();
        protected abstract string InitializeDefaultTheme();

        public ThemeInitializer()
        {
            Resource = InitializeResource();
            DefaultTheme = InitializeDefaultTheme();
        }
    }
}
