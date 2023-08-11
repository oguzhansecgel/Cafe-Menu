using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
