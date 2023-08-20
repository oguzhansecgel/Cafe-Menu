using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.UI.Controllers.UI
{
    public class DefaultController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
		[AllowAnonymous]

		public IActionResult GetContentDetail([FromQuery]int categoryId)
        {
            return ViewComponent("_ContentPartial", new
            {
                categoryId = categoryId
            }) ;
        }
    }
}
 