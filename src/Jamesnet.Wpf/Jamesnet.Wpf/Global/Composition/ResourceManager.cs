using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Composition;

    public class ResourceManager : IResourceManager
    { 
    private string _currentTheme;
    private string _currentLanguage;
    private readonly JamesApplication _app;
    private readonly ResourceInitializer _themeInitializer;

    internal Dictionary<string, ResourceDictionary> ThemeResources { get; private set; }
    internal Dictionary<string, ResourceDictionary> LanguageResources { get; private set; }
    internal List<ThemeModel> Themes { get; private set; }
    internal List<ThemeModel> Languages { get; private set; }

    public ResourceManager(JamesApplication app, ResourceInitializer themeInitializer)
    {
        _app = app;
        _themeInitializer = themeInitializer;
        _currentTheme = _themeInitializer.DefaultTheme;
        _currentLanguage = _themeInitializer.DefaultLanguage;
        ThemeResources = GetThemes(_themeInitializer.ThemeResource);
        LanguageResources = GetThemes(_themeInitializer.LanguageResource);
        Themes = GetList();
        Languages = GetList();
        SwitchTheme(_themeInitializer.DefaultTheme);
        SwitchLanguage(_themeInitializer.DefaultLanguage);
    }

    private Dictionary<string, ResourceDictionary> GetThemes(string resourcePath)
    {
        Dictionary<string, ResourceDictionary> dics = new();

        Assembly assembly = Assembly.GetEntryAssembly();

        using Stream stream = assembly.GetManifestResourceStream(resourcePath);
        using StreamReader reader = new(stream);
        StringReader r = new(reader.ReadToEnd());

        Deserializer deserializer = new();
        ThemeRoot themeObject = deserializer.Deserialize<ThemeRoot>(r);

        //foreach (ThemeMode item in Enum.GetValues(typeof(ThemeMode)))
        {
            Dictionary<string, ResourceDictionary> res = new();

            if (themeObject.Themes is not null)
            {
                foreach (var theme in themeObject.Themes)
                {
                    foreach (var prop in theme.Colors.GetType().GetProperties())
                    {
                        Color color = (Color)ColorConverter.ConvertFromString(theme.Colors.Get(prop.Name));
                        SolidColorBrush solidColor = new(color);

                        if (!res.ContainsKey(prop.Name))
                        {
                            res.Add(prop.Name, new ResourceDictionary());
                        }

                        res[prop.Name].Add(theme.Key, solidColor);
                    }
                }
            }

            if (themeObject.Fonts is not null)
            {
                foreach (var theme in themeObject.Fonts)
                {
                    foreach (var prop in theme.Fonts.GetType().GetProperties())
                    {
                        FontFamily font = new(theme.Fonts.Get(prop.Name));

                        if (!res.ContainsKey(prop.Name))
                        {
                            res.Add(prop.Name, new ResourceDictionary());
                        }

                        res[prop.Name].Add(theme.Key, font);
                    }
                }
            }

            if (themeObject.Languages is not null)
            {
                foreach (var theme in themeObject.Languages)
                {
                    foreach (var prop in theme.Fonts.GetType().GetProperties())
                    {
                        string text = theme.Fonts.Get(prop.Name);

                        if (!res.ContainsKey(prop.Name))
                        {
                            res.Add(prop.Name, new ResourceDictionary());
                        }

                        res[prop.Name].Add(theme.Key, text);
                    }
                }
            }

            foreach (var dic in res)
            {
                dics.Add(dic.Key, dic.Value);
            }
        }
        return dics;
    }

    public List<ThemeModel> GetList()
    {
        var source = new List<ThemeModel>();
        foreach (var lang in ThemeResources)
        {
            source.Add(new ThemeModel(lang.Key, lang.Key));
        }
        return source;
    }

    //public List<ThemeModel> ToList()
    //{
    //    return Themes;
    //}

    //public ThemeModel ToCode()
    //{
    //    return Themes.FirstOrDefault(x => x.Code == _currentTheme);
    //}

    public void SwitchTheme(string value)
    {
        _app.Resources.MergedDictionaries.Remove(ThemeResources[_currentTheme]);
        _app.Resources.MergedDictionaries.Add(ThemeResources[value]);
        _currentTheme = value;
    }

    public void SwitchLanguage(string value)
    {
        _app.Resources.MergedDictionaries.Remove(LanguageResources[_currentLanguage]);
        _app.Resources.MergedDictionaries.Add(LanguageResources[value]);
        _currentLanguage = value;
    }
}
