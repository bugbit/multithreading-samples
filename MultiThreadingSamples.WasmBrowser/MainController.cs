using MultiThreadingSamples.Shared;
using System;

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
        var factoryControllers = FactoryControllers.Instance;
        SampleBaseController? oldSample = factoryControllers.GetSampleController();

        try
        {
            var controller = factoryControllers.CreateSampleController(idSample);

            FactoryControllers.RemoveSampleController(ref oldSample);

            controller.Execute();
        }
        catch (Exception ex)
        {
            if (oldSample != null)
                factoryControllers.SetSampleController(oldSample);

            Interop.Alert(ex.Message);
        }
    }
}
