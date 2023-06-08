using MultiThreadingSamples.WasmBrowser.Models;

namespace MultiThreadingSamples.WasmBrowser.Views;

public class MainView : ViewBase
{
    private readonly Sample[] samples;

    public MainView(Sample[] samples)
    {
        this.samples = samples;
    }

    public void UpdateMenu()
    {

    }
}
