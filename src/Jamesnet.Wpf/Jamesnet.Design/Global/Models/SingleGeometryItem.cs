using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamesnet.Design.Global.Models
{
    internal class SingleGeometryItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
