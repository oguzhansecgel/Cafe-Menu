using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.ViewComponents.Default
{
    public class _ScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
