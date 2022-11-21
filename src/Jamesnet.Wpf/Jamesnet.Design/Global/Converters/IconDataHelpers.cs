using Jamesnet.Design.Global.Providers;

internal static class IconDataHelpers
{
    internal static string GetData(string name)
    {
        return SingleGeometryProvider.data.Items.First(x => x.Name == "alpha_b_box").Data;
    }
}