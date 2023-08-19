using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    public class AdminPanelWelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
