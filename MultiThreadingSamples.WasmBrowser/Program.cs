using MultiThreadingSamples.WasmBrowser.Controllers;
using System;
using System.Runtime.InteropServices.JavaScript;

MainController mainController = new MainController();

mainController.Index();
//Console.WriteLine("Hello, Browser!");

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World! Greetings from {GetHRef()}";
        Console.WriteLine(text);
        return text;
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
}
