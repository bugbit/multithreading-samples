using MultiThreadingSamples.WasmBrowser.Models;
using MultiThreadingSamples.WasmBrowser.Views;

namespace MultiThreadingSamples.WasmBrowser.Controllers;

public class MainController
{
    private readonly MainView view;
    private readonly Sample[] samples;

    public MainController()
    {
        samples = new[]
        {
            new Sample{ Name="ComputePi",Description="Estimates the value of PI" }
        };
        view = new MainView(samples);
    }

    public void Index()
    {

    }
}
