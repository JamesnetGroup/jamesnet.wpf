using Jamesnet.Wpf.Models;
using System.Collections.Generic;

namespace Jamesnet.Wpf.Composition
{
    public interface IThemeManager
    {
        public interface IThemeManager
        {
            List<ThemeModel> ToList();
            ThemeModel ToCode();
            void Switch(ThemeMode value);
        }
    }
}