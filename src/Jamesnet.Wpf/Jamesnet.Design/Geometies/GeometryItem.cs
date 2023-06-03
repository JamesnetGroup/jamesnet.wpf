using Newtonsoft.Json;

namespace Jamesnet.Design.Geometries
{
    internal class GeometryItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
