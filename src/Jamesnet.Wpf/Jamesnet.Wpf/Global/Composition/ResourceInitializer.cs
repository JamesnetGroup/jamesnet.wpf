namespace Jamesnet.Wpf.Global.Composition
{
    public abstract class BaseResourceInitializer
    {
        public string ThemePath { get; }
        public string DefaultLocale { get; }
        public string DefaultThemeName { get; }
        public string LocalePath { get; }

        protected abstract string FetchThemePath();
        protected abstract string DetermineDefaultThemeName();

        protected abstract string FetchLocalePath();
        protected abstract string DetermineDefaultLocale();

        public BaseResourceInitializer()
        {
            ThemePath = FetchThemePath();
            DefaultThemeName = DetermineDefaultThemeName();
            LocalePath = FetchLocalePath();
            DefaultLocale = DetermineDefaultLocale();
        }
    }
}

