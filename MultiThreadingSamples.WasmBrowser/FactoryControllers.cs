using MultiThreadingSamples.Shared;
using System;

namespace MultiThreadingSamples.WasmBrowser;

public class FactoryControllers
{
    private static readonly Lazy<FactoryControllers> _instance = new Lazy<FactoryControllers>(() => new FactoryControllers());
    private MainController? _mainController;
    private SampleBaseController? _sampleController;

    private FactoryControllers() { }

    public static FactoryControllers Instance => _instance.Value;

    public MainController CreateMainController() => (_mainController = new MainController());

    public MainController GetMainController() => _mainController;

    public SampleBaseController? CreateSampleController(int idSample)
       => (_sampleController = idSample switch
       {
           Sample.IdComputePi => new ComputePiController(),
           _ => null
       });

    public void SetSampleController(SampleBaseController sampleController) => _sampleController = sampleController;
    public SampleBaseController? GetSampleController() => _sampleController;
    public T? GetSampleController<T>() where T : SampleBaseController => _sampleController as T;

    public void RemoveSampleController() => RemoveSampleController(ref _sampleController);

    public static void RemoveSampleController(ref SampleBaseController? sampleController)
    {
        if (sampleController != null)
        {
            sampleController.Dispose();
            sampleController = null;
        }
    }
}
