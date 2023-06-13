using MultiThreadingSamples.Shared;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadingSamples.WasmBrowser
{
    public class MainView : View
    {
        //MultiThreadingSamples
        public void Render()
        {
            Interop.SetHtml("app", @"
<div class=""page"">
    <div class=""sidebar"">
        <div class=""top-row ps-3 navbar navbar-dark"">
            <div class=""container-fluid"">
                <a class=""navbar-brand"" href="""">MultiThreadingSamples</a>
                <button title=""Navigation menu"" class=""navbar-toggler"" onclick=""ToggleNavMenu"">
                    <span class=""navbar-toggler-icon""></span>
                </button>
            </div>
        </div>
        <div class=""nav-scrollable"" @onclick=""ToggleNavMenu"">
            <ul id=""menulist"" class=""nav flex-column"">
            </ul>
        </div>
    </div>
    <article id=""main"" class=""content px-4"">
    </article>
</div>
");
        }

        public void RenderMenu(ICollection<Sample> samples)
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
    <a class=""nav-link"" href=""javascript:void(0)"" onclick=""globalThis.Main.ExecuteSample({sample.Id})"">{sample.Name}</a>
</li >
");
        }
    }
}
