using MultiThreadingSamples.Shared;

namespace MultiThreadingSamples.WasmBrowser;

public class MainController
{
    private MainView _view = new MainView();

    public void Main()
    {
        _view.Render();
        _view.RenderMenu(Samples.Instance);
    }

    public void ExecuteSample(int idSample)
    {
        var controller = CreateController(idSample);
    }

    private SampleBaseController? CreateController(int idSample)
        => idSample switch
        {
            Sample.IdComputePi => new ComputePiController(),
            _ => null
        };
}
