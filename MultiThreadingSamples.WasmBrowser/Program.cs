using MultiThreadingSamples.WasmBrowser;
using System;
using System.Runtime.InteropServices.JavaScript;

FactoryControllers.Instance.CreateMainController().Main();

Console.WriteLine("Hello, Browser!");

public partial class Interop
{
    [JSImport("window.alert", "main.js")]
    internal static partial void Alert(string msg);
    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
    [JSImport("window.print", "main.js")]
    internal static partial void Print(string s);
    [JSImport("window.setDisable", "main.js")]
    internal static partial void SetDisable(string id, bool disable);
}

public partial class Main
{
    [JSExport]
    internal static void ExecuteSample(int idSample) => FactoryControllers.Instance.GetMainController()?.ExecuteSample(idSample);
}

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World! Greetings from {Interop.GetHRef()}";
        Console.WriteLine(text);
        return text;
    }
}

public partial class ComputePi
{
    [JSExport]
    internal static void OnClickSerialPi()
    {
        Console.WriteLine("SerialPi");
    }

    [JSExport]
    internal static void OnClickThreadPi()
    {
        Console.WriteLine("ThreadPi");
    }
}