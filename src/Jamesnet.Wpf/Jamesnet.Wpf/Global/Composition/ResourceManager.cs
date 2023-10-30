using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Event;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Global.Event;
using Jamesnet.Wpf.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Composition
{

    public class ResourceManager : IResourceManager
    {
        private string _currentTheme;
        private string _currentLanguage;
        private readonly JamesApplication _app;
        private readonly BaseResourceInitializer _themeInitializer;
        private readonly IEventHub _eventHub;

        internal Dictionary<string, ResourceDictionary> ThemeResources { get; private set; }
        internal Dictionary<string, ResourceDictionary> LanguageResources { get; private set; }
        internal List<ThemeModel> Themes { get; private set; }
        internal List<ThemeModel> Languages { get; private set; }

        public ResourceManager(JamesApplication app,
                               BaseResourceInitializer themeInitializer,
                               IEventHub eventHub)
        {
            this._app = app;
            this._themeInitializer = themeInitializer;
            this._eventHub = eventHub;
            this._currentTheme = _themeInitializer.DefaultThemeName;
            this._currentLanguage = _themeInitializer.DefaultLocale;
            this.ThemeResources = GetThemes (_themeInitializer.ThemePath);
            this.LanguageResources = GetThemes (_themeInitializer.LocalePath);
            this.Themes = GetList ();
            this.Languages = GetList ();
            SwitchTheme (_themeInitializer.DefaultThemeName);
            SwitchLanguage (_themeInitializer.DefaultLocale);
        }

        private Dictionary<string, ResourceDictionary> GetThemes(string resourcePath)
        {
            Dictionary<string, ResourceDictionary> dics = new Dictionary<string, ResourceDictionary> ();

            Assembly assembly = Assembly.GetEntryAssembly ();

            using (Stream stream = assembly.GetManifestResourceStream (resourcePath))
            using (StreamReader reader = new StreamReader (stream))
            {
                StringReader r = new StringReader (reader.ReadToEnd ());

                Deserializer deserializer = new Deserializer ();
                ThemeRoot themeObject = deserializer.Deserialize<ThemeRoot> (r);

                //foreach (ThemeMode item in Enum.GetValues(typeof(ThemeMode)))
                {
                    Dictionary<string, ResourceDictionary> res = new Dictionary<string, ResourceDictionary> ();

                    if (themeObject.Themes != null)
                    {
                        foreach (var theme in themeObject.Themes)
                        {
                            foreach (var prop in theme.Colors.GetType().GetProperties())
                            {
                                Color color = (Color)ColorConverter.ConvertFromString(theme.Colors.Get(prop.Name));
                                //SolidColorBrush solidColor = new SolidColorBrush(color);

                                if (!res.ContainsKey(prop.Name))
                                {
                                    res.Add(prop.Name, new ResourceDictionary());
                                }

                                res[prop.Name].Add(theme.Key, color);
                            }
                        }
                    }

                    if (themeObject.Fonts != null)
                    {
                        foreach (var theme in themeObject.Fonts)
                        {
                            foreach (var prop in theme.Fonts.GetType ().GetProperties ())
                            {
                                FontFamily font = new FontFamily (theme.Fonts.Get (prop.Name));

                                if (!res.ContainsKey (prop.Name))
                                {
                                    res.Add (prop.Name, new ResourceDictionary ());
                                }

                                res[prop.Name].Add (theme.Key, font);
                            }
                        }
                    }

                    if (themeObject.Languages != null)
                    {
                        foreach (var theme in themeObject.Languages)
                        {
                            foreach (var prop in theme.Fonts.GetType ().GetProperties ())
                            {
                                string text = theme.Fonts.Get (prop.Name);

                                if (!res.ContainsKey (prop.Name))
                                {
                                    res.Add (prop.Name, new ResourceDictionary ());
                                }

                                res[prop.Name].Add (theme.Key, text);
                            }
                        }
                    }

                    foreach (var dic in res)
                    {
                        dics.Add (dic.Key, dic.Value);
                    }
                }
            }
                
            return dics;
        }

        public List<ThemeModel> GetList()
        {
            var source = new List<ThemeModel> ();
            foreach (var lang in ThemeResources)
            {
                source.Add (new ThemeModel (lang.Key, lang.Key));
            }
            return source;
        }

        public void SwitchTheme(string value)
        {
            _app.Resources.MergedDictionaries.Remove (ThemeResources[_currentTheme]);
            _app.Resources.MergedDictionaries.Add (ThemeResources[value]);
            _currentTheme = value;

            this._eventHub.Publish<SwitchThemePubsub, string> (value);
        }

        public void SwitchLanguage(string value)
        {
            _app.Resources.MergedDictionaries.Remove (LanguageResources[_currentLanguage]);
            _app.Resources.MergedDictionaries.Add (LanguageResources[value]);
            _currentLanguage = value;

            this._eventHub.Publish<SwitchLanguagePubsub, string> (value);
        }
    }
}