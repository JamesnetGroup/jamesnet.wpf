using Newtonsoft.Json;

namespace Jamesnet.Design.Images
{
    internal class ImageItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
