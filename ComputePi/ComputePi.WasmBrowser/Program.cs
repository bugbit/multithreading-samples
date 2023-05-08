using ComputePi.Shared;
using System;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Hello, Browser!");

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = Time(CalculatePI.SerialPi);
        Console.WriteLine(text);
        return text;
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();

    static internal string Time<T>(Func<T> work)
    {
        var r = CalculatePI.Time(work);

        return r.elapsed + ": " + r.result;
    }
}


