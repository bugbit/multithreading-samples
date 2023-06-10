using MultiThreadingSamples.Shared;

namespace MultiThreadingSamples.WasmBrowser;

public class MainController
{
    private MainView _view = new MainView();

    public void Main()
    {
        _view.Show();
        _view.ShowMenu(Samples.Instance);
    }
}
