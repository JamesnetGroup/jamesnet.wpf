
using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Models
{
    public class ThemePack
    {
        [YamlMember(Alias = "key")]
        public string Key { get; set; }
        [YamlMember(Alias = "colors")]
        public ThemeUnit Colors { get; set; }
    }
}