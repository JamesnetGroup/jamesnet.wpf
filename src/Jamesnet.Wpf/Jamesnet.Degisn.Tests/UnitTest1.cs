using Jamesnet.Design.Global.Converters;
using Jamesnet.Design.Global.Providers;

namespace Jamesnet.Degisn.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var data = IconData.AlphaBBox;
            Assert.NotEmpty(data);
        }
    }
}