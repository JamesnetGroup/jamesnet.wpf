using Jamesnet.Design.Global.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Jamesnet.Design.Global.Providers
{
    public class SingleGeometryProvider
    {
        internal static SingleGeometryRoot data;

        static SingleGeometryProvider()
        {
            Build();
        }

        private static void Build()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Jamesnet.Design.Properties.Resources.SingleGeometry.yaml";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            StringReader r = new(reader.ReadToEnd());
            Deserializer deserializer = new();
            object yamlObject = deserializer.Deserialize<object>(r);

            JsonSerializer js = new();
            StringWriter w = new();
            js.Serialize(w, yamlObject);
            string jsonText = w.ToString();
            data = JsonConvert.DeserializeObject<SingleGeometryRoot>(jsonText);
        }
    }
}
