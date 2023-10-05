using Jamesnet.Wpf.Global.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnatomyAnalyzerTestApp.Properties
{
    public class ThemeSettings : ResourceInitializer
    {
        protected override string GetDefaultTheme()
        {
            return "Black";
        }

        protected override string GetThemeResource()
        {
            return "AnatomyAnalyzerTestApp.Properties.Resources.theme.yaml";
        }

        protected override string GetDefaultLanguage()
        {
            return "KOR";
        }

        protected override string GetLanguageResource()
        {
            return "AnatomyAnalyzerTestApp.Properties.Resources.language.yaml";
        }
    }
}
