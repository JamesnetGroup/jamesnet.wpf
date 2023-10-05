using YamlDotNet.Serialization;

namespace Jamesnet.Wpf.Models
{
    public class SolidColorBrushUnit
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

    public class FontFamilyUnit
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

    public class LanguageUnit
    {
        [YamlMember(Alias = "usa")]
        public string USA { get; set; }
        [YamlMember(Alias = "kor")]
        public string KOR { get; set; }
        [YamlMember(Alias = "chn")]
        public string CHN { get; set; }
        [YamlMember(Alias = "jpn")]
        public string JPN { get; set; }
        [YamlMember(Alias = "vnm")]
        public string VNM { get; set; }
        [YamlMember(Alias = "esp")]
        public string ESP { get; set; }

        internal string Get(string item)
        {
            switch (item.ToUpper())
            {
                case "USA": return USA;
                case "KOR": return KOR;
                case "CHN": return CHN;
                case "JPN": return JPN;
                case "VNM": return VNM;
                case "ESP": return ESP;
            }
            return "";
        }
    }
}