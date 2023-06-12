namespace MultiThreadingSamples.WasmBrowser
{
    public class ComputePiView : View
    {
        public void Render()
        {
            Interop.SetHtml("main", @"
<ul>
    <li><button onclick=""globalThis.ComputePi.OnClickSerialPi()"">SerialPi</button></li>
    <li> <button onclick=""globalThis.ComputePi.OnClickThreadPi()"">ThreadPi</button></li>
</ul>
");
        }
    }
}
