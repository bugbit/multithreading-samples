using ComputePi.Shared;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Threading;

[assembly: SupportedOSPlatform("browser")]

Console.WriteLine("Hello, Browser!");

MyClass.Print("Ready!!<br>");

public partial class MyClass
{
    public const int num_steps = 100000000;

    [JSExport]
    internal static void SerialPi()
    {
        Print("SerialPi: ");

        var text = Time(CalculatePI.SerialPi);

        Print(text);
    }

    [JSExport]
    internal static void ThreadPi()
    {
        Print("ThreadPi: ");

        var text = Time(() => CalculatePI.ThreadPi(4));

        Print(text);
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
    [JSImport("window.print", "main.js")]
    internal static partial void Print(string s);

    static internal string Time<T>(Func<T> work)
    {
        var r = CalculatePI.Time(work);

        return $"{r.elapsed} : {r.result}<br>";
    }
}


