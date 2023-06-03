using Newtonsoft.Json;

namespace Jamesnet.Design.Geometries
{
    internal class GeometryRoot
    {
        [JsonProperty("geometries")]
        public List<GeometryItem> Items { get; set; }
    }
}
