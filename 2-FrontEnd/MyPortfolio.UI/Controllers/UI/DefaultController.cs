using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.Controllers.UI
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetContentDetail([FromQuery]int categoryId)
        {
            return ViewComponent("_ContentPartial", new
            {
                categoryId = categoryId
            }) ;
        }
    }
}
 