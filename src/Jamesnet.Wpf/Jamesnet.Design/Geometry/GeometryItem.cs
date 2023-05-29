using Newtonsoft.Json;

namespace Jamesnet.Design.Geometry
{
    internal class GeometryItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
