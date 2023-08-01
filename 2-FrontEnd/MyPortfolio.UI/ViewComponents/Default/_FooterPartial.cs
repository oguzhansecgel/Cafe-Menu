using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.ViewComponents.Default
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
