using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jamesnet.Design.Geometries
{
    internal class GeometryRoot
    {
        [JsonProperty("geometries")]
        public List<GeometryItem> Items { get; set; }
    }
}
