using System;
using DarkWindowTest3.Properties;

namespace DarkWindowTest3;

internal class Starter
{
    [STAThread]
    private static void Main(string[] args)
    {
        _ = new App ()
            .AddInversionModule<DirectModules> ()
            .AddInversionModule<ViewModules> ()
            .AddWireDataContext<WireDataContext> ()
            .Run ();
    }
}