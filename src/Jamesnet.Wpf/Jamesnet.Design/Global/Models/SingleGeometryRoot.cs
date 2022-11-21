using Newtonsoft.Json;

namespace Jamesnet.Design.Global.Models
{
    internal class SingleGeometryRoot
    {
        [JsonProperty("geometries")]
        public List<SingleGeometryItem> Items { get; set; }
    }
}
