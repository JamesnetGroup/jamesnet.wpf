using Newtonsoft.Json;

namespace Jamesnet.Design.Geometry
{
    internal class GeometryRoot
    {
        [JsonProperty("geometries")]
        public List<GeometryItem> Items { get; set; }
    }
}
