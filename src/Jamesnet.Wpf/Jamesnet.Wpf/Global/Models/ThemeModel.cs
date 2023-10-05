using Jamesnet.Wpf.Controls;

namespace Jamesnet.Wpf.Models
{
    public class ThemeModel
    {
        public string Code { get; set; }
        public string Theme { get; set; }
        public IconType IconType { get; set; }
        public string Value { get; set; }

        public ThemeModel(string code, string theme)
        {
            Code = code;
            Theme = theme;
            Value = code.ToString();
            //IconType = GetThemeIcon(code);
        }

        //private static IconType GetThemeIcon(string key)
        //{
        //    return key switch
        //    {
        //        ThemeMode.Black => IconType.Account,
        //        ThemeMode.Light => IconType.CalendarBlankOutline,
        //        _ => IconType.Account
        //    };
        //}
    }
}