using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Models
{

    public class ThemeRoot
    {
        [YamlMember(Alias = "themes")]
        public List<ThemePack> Themes { get; set; }
    }
}