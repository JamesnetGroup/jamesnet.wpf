namespace Jamesnet.Wpf.Global.Composition
{
    public abstract class ResourceInitializer
    {
        public string ThemeResource { get; }
        public string DefaultLanguage { get; }
        public string DefaultTheme { get; }
        public string LanguageResource { get; }

        protected abstract string GetThemeResource();
        protected abstract string GetDefaultTheme();

        protected abstract string GetLanguageResource();
        protected abstract string GetDefaultLanguage();

        public ResourceInitializer()
        {
            ThemeResource = GetThemeResource ();
            DefaultTheme = GetDefaultTheme ();
            LanguageResource = GetLanguageResource ();
            DefaultLanguage = GetDefaultLanguage ();
        }
    }
}

