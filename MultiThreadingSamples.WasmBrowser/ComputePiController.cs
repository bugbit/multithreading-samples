namespace MultiThreadingSamples.WasmBrowser
{
    public class ComputePiController : SampleBaseController
    {
        private ComputePiView _view = new ComputePiView();

        public override bool Execute()
        {
            _view.Render(); 
            
            return true;
        }
    }
}
