
using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Models
{
    public class ThemePack
    {
        [YamlMember(Alias = "key")]
        public string Key { get; set; }
        [YamlMember(Alias = "colors")]
        public SolidColorBrushUnit Colors { get; set; }
    }

    public class FontPack
    {
        [YamlMember(Alias = "key")]
        public string Key { get; set; }
        [YamlMember(Alias = "fonts")]
        public FontFamilyUnit Fonts { get; set; }
    }

    public class LanguagePack
    {
        [YamlMember(Alias = "key")]
        public string Key { get; set; }
        [YamlMember(Alias = "items")]
        public LanguageUnit Fonts { get; set; }
    }
}