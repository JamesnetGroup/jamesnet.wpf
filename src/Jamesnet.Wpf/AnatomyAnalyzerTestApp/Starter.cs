using AnatomyAnalyzerTestApp.Properties;
using Jamesnet.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnatomyAnalyzerTestApp
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .InitializeTheme<ThemeSettings>()
                .Run();
        }
    }
}
