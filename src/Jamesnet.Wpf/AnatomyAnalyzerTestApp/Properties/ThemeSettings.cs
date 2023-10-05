using Jamesnet.Wpf.Global.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnatomyAnalyzerTestApp.Properties
{
    public class ThemeSettings : ThemeInitializer
    {
        protected override string InitializeDefaultTheme()
        {
            return "Black";
        }

        protected override string InitializeResource()
        {
            return "AnatomyAnalyzerTestApp.Properties.Resources.theme.yaml";
        }
    }
}
