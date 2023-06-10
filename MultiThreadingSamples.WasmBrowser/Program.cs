using MultiThreadingSamples.WasmBrowser;
using System;
using System.Runtime.InteropServices.JavaScript;

Main.Execute();

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
    private static readonly MainController mainController = new MainController();

    internal static void Execute() => mainController.Main();

    [JSExport]
    public static void ExecuteSample(int idSample) => mainController.ExecuteSample(idSample);
    [JSExport]
    public static void SetSample(string sample)
    {

    }
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
    internal static void Main() => Interop.Alert("Hello");
    [JSExport]
    internal static void OnReady()
    {
        Interop.SetDisable("cmdserialpi", true);
        Interop.SetDisable("cmdthreadpi", true);
    }
    [JSExport]
    internal static void SerialPi()
    {
        Console.WriteLine("SerialPi");
    }

    [JSExport]
    internal static void ThreadPi()
    {
        Console.WriteLine("ThreadPi");
    }
}