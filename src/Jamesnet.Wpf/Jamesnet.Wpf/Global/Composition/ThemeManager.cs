using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using YamlDotNet.Serialization;
using Jamesnet.Wpf.Models;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Extensions;
using System.Reflection;
using Jamesnet.Wpf.Global.Composition;

namespace Jamesnet.Wpf.Composition
{

    public class ThemeManager : IThemeManager
    {

        private string _currentTheme;
        private readonly JamesApplication _app;
        private readonly ThemeInitializer _themeInitializer;

        internal Dictionary<string, ResourceDictionary> Resources { get; private set; }
        internal List<ThemeModel> Themes { get; private set; }

        public ThemeManager(JamesApplication app, ThemeInitializer themeInitializer)
        {
            _app = app;
            _themeInitializer = themeInitializer;
            _currentTheme = _themeInitializer.DefaultTheme;
            Resources = GetThemes();
            Themes = GetList();
            Switch(_themeInitializer.DefaultTheme);
        }

        private Dictionary<string, ResourceDictionary> GetThemes()
        {
            Dictionary<string, ResourceDictionary> dics = new();

            Assembly assembly = Assembly.GetEntryAssembly();
            var resourceName = _themeInitializer.Resource;

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            StringReader r = new(reader.ReadToEnd());

            Deserializer deserializer = new();
            ThemeRoot themeObject = deserializer.Deserialize<ThemeRoot>(r);

            foreach (ThemeMode item in Enum.GetValues(typeof(ThemeMode)))
            {
                ResourceDictionary res = new();

                foreach (var theme in themeObject.Themes)
                {
                    Color color = (Color)ColorConverter.ConvertFromString(theme.Colors.Get(item.ToName()));
                    SolidColorBrush solidColor = new(color);
                    res.Add(theme.Key, solidColor);
                }
                dics.Add(item.ToName(), res);
            }
            return dics;
        }

        public List<ThemeModel> GetList()
        {
            var source = new List<ThemeModel>();
            foreach (var lang in Resources)
            {
                source.Add(new ThemeModel(lang.Key, lang.Key));
            }
            return source;
        }

        public List<ThemeModel> ToList()
        {
            return Themes;
        }

        public ThemeModel ToCode()
        {
            return Themes.FirstOrDefault(x => x.Code == _currentTheme);
        }

        public void Switch(string value)
        {
            _app.Resources.MergedDictionaries.Remove(Resources[_currentTheme]);
            _app.Resources.MergedDictionaries.Add(Resources[value]);
            _currentTheme = value;
        }
    }
}
