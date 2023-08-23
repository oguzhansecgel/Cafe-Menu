using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.RequestModel.Count;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    public class AdminPanelWelcomeController : Controller
    {
        private readonly Context _context;

		public AdminPanelWelcomeController(Context context)
		{
			_context = context;
		}

		public IActionResult Index()
        {

			var totalProductCount = _context.Products.Count();  
            var totalCategoryCount = _context.Categories.Count();

            var viewModel = new CountProductOrCategory
			{
				Product = totalProductCount,
				Category = totalCategoryCount,

			};
			
			return View(viewModel);
        }
    }
}
