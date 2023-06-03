using System.Runtime.CompilerServices;

namespace Jamesnet.Design.Images
{
    public static class ImageConverter
    {
        public static string GetData([CallerMemberName] string name = null)
        {
            return $"/Jamesnet.Design;component/Properties/Images/{name.ToLower()}.png";
        }
    }
}