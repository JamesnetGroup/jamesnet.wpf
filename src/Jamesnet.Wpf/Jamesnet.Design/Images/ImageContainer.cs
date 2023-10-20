using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using YamlDotNet.Serialization;

namespace Jamesnet.Design.Images
{
    public class ImageContainer
    {
        internal static ImageRoot _data;
        internal static Dictionary<string, ImageItem> _items;

        static ImageContainer()
        {
            Build();
        }

        private static void Build()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Jamesnet.Design.Properties.Resources.images.yaml";

            using (Stream stream = assembly.GetManifestResourceStream (resourceName))
            using (StreamReader reader = new StreamReader (stream))
            {
                StringReader r = new StringReader (reader.ReadToEnd ());
                Deserializer deserializer = new Deserializer ();
                object yamlObject = deserializer.Deserialize<object> (r);

                JsonSerializer js = new JsonSerializer ();
                StringWriter w = new StringWriter ();
                js.Serialize (w, yamlObject);
                string jsonText = w.ToString ();
                _data = JsonConvert.DeserializeObject<ImageRoot> (jsonText);
                _items = new Dictionary<string, ImageItem> ();

                foreach (var item in _data.Items)
                {
                    _items.Add (item.Name, item);
                }
            }
        }
    }
}
