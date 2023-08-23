using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.ProductImageDto;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.Dtos.ImageDto;
using MyPortfolio.UI.Models.RequestModel.ProductImage;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
	public class AdminImageProductController : Controller
	{

		private readonly Context _context;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;


		public AdminImageProductController(IHttpClientFactory httpClientFactory, IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, Context context)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
			_environment = environment;

			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			
			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync("http://localhost:5185/api/ProductImage");
			if (responserMessage.IsSuccessStatusCode)
			{
				var jsonData = await responserMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		public async Task<IActionResult> DeleteProductImage(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5185/api/ProductImage/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();


		}


		[HttpGet]
		public async Task<IActionResult> CreateProductImage(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5185/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<AddProductImageVM>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProductImage(AddProductImageVM model)
		{

			if (ModelState.IsValid)
			{
				var date = DateTime.Now;
				var extension = Path.GetExtension(model.FileImage.FileName);
				var fileName = $"{date.Day}_{date.Month}_{date.Year}_{date.Hour}_{date.Minute}_{date.Second}_{date.Millisecond}{extension}";
				var filePath = Path.Combine(_environment.WebRootPath, _configuration["Paths:ProductImages"], fileName);

				using (FileStream fs = new FileStream(filePath, FileMode.Create))
				{

					using (var httpclient = new HttpClient())
					{
						var formData = new MultipartFormDataContent();
						formData.Add(new StringContent(model.ProductId.ToString()), "ProductID");
						using (var stream = new MemoryStream())
						{
							model.FileImage.CopyTo(stream);
							var byteArrayContent = new ByteArrayContent(stream.ToArray());
							formData.Add(byteArrayContent, "UploadedImage", model.FileImage.FileName);
						}

						var response = await httpclient.PostAsync("http://localhost:5185/api/ProductImage", formData);

						if (response.IsSuccessStatusCode)
						{
							return RedirectToAction("Index", "Product");
						}
						else
						{
							return View();
						}
					}
				}
			}
			return View();

		}



	}
}

