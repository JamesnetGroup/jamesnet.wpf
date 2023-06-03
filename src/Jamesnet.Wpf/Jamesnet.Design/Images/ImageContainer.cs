using Newtonsoft.Json;
using System.Reflection;
using YamlDotNet.Serialization;

namespace Jamesnet.Design.Images
{
    //public class ImageContainer
    //{
    //    internal static ImageRoot _data;
    //    internal static Dictionary<string, ImageItem> _items;

    //    static ImageContainer()
    //    {
    //        Build();
    //    }

    //    private static void Build()
    //    {
    //        Assembly assembly = Assembly.GetExecutingAssembly();
    //        var resourceName = "Jamesnet.Design.Properties.Resources.images.yaml";

    //        using Stream stream = assembly.GetManifestResourceStream(resourceName);
    //        using StreamReader reader = new(stream);
    //        StringReader r = new(reader.ReadToEnd());
    //        Deserializer deserializer = new();
    //        object yamlObject = deserializer.Deserialize<object>(r);

    //        JsonSerializer js = new();
    //        StringWriter w = new();
    //        js.Serialize(w, yamlObject);
    //        string jsonText = w.ToString();
    //        _data = JsonConvert.DeserializeObject<ImageRoot>(jsonText);
    //        _items = new();

    //        foreach (var item in _data.Items)
    //        {
    //            _items.Add(item.Name, item);
    //        }
    //    }
    //}
}
