using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Models
{

    public class ThemeRoot
    {
        [YamlMember(Alias = "themes")]
        public List<ThemePack> Themes { get; set; }
        [YamlMember(Alias = "fonts")]
        public List<FontPack> Fonts { get; set; }
        [YamlMember(Alias = "languages")]
        public List<LanguagePack> Languages { get; set; }
    }
}