using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.UI.Dtos.AboutDto;
using MyPortfolio.UI.Dtos.CategoryDto;
using MyPortfolio.UI.Dtos.ProductDto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
	public class ProductController : Controller
	{
        Context c = new Context();

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<IActionResult> Index() // listeleme metodu
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5185/api/Product");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                   

				return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5185/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }
                                           ).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5185/api/Product/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5185/api/Product/{id}");
            List<SelectListItem> value = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }
                              ).ToList();
            ViewBag.v1 = value;
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:5185/api/Product/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
