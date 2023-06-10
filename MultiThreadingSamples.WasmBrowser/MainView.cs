using MultiThreadingSamples.Shared;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadingSamples.WasmBrowser
{
    public class MainView : View
    {
        public void Show()
        {
            Interop.SetHtml("app", @"
<div class=""page"">
    <div class=""sidebar"">
        <div class=""top-row pl-4 navbar navbar-dark"">
            <a class=""navbar-brand"" href=""javascript:void(0)"">MultiThreadingSamples</a>
            <button class=""navbar-toggler"" onclick=""ToggleNavMenu"">
                <span class=""navbar-toggler-icon""></span>
            </button>
        </div>
        <div class=""@NavMenuCssClass"" @onclick=""ToggleNavMenu"">
            <ul id=""menulist"" class=""nav flex-column"">
            </ul>
        </div>
    </div>
    <div class=""main"">
    </div>
</div>
");
        }

        public void ShowMenu(ICollection<Sample> samples)
        {
            var sb = new StringBuilder();

            foreach (var sample in samples)
                SetMenuSample(sb, sample);

            Interop.SetHtml("menulist", sb.ToString());
        }

        private void SetMenuSample(StringBuilder sb, Sample sample)
        {
            sb.AppendLine(@$"
<li class=""nav-item px-3"">
    <a class=""nav-link"" href=""javascript:void(0)"" onclick=""globalThis.{sample.JSFunction}()"">{sample.Name}</a>
</ li >
");
        }
    }
}
