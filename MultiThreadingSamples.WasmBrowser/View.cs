using System.Runtime.InteropServices.JavaScript;

namespace MultiThreadingSamples.WasmBrowser;

public partial class View
{
    protected partial class Interop
    {
        [JSImport("view.setHtml", "main.js")]
        internal static partial void SetHtml(string id, string html);
    }
}
