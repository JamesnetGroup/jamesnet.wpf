using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Models
{
    public class ThemeUnit
    {
        [YamlMember(Alias = "black")]
        public string Black { get; set; }
        [YamlMember(Alias = "light")]
        public string Light { get; set; }

        internal string Get(string item)
        {
            switch (item.ToUpper())
            {
                case "BLACK": return Black;
                case "LIGHT": return Light;
            }
            return "";
        }
    }
}