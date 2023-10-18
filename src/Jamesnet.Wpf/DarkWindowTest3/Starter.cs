using System;

namespace DarkWindowTest3;

internal class Starter
{
    [STAThread]
    private static void Main(string[] args)
    {
        _ = new App ()
            .Run ();
    }
}