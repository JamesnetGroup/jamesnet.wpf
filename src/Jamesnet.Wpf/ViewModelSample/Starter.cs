using System;
using ViewModelSample.Settings;

namespace ViewModelSample
{
        internal class Starter
        {
                [STAThread]
                private static void Main(string[] args)
                {
                        _ = new App()
                            .AddInversionModule<ViewModules>()
                            .AddInversionModule<DirectModules>()
                            .AddWireDataContext<WireDataContext>()
                            .Run();
                }
        }
}
