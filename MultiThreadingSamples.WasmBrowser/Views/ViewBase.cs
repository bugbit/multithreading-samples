using System.Runtime.InteropServices.JavaScript;

namespace MultiThreadingSamples.WasmBrowser.Views;

public partial class ViewBase
{
    internal static partial class Interop
    {
        [JSImport("window.setContextElementById", "main.js")]
        internal static partial void SetContextElementById(string id, string context);
    }
}
