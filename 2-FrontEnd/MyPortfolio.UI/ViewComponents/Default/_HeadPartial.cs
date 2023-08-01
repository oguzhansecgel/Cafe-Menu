using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.ViewComponents.Default
{
    public class _HeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
