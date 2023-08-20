using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Models.Dtos.ProductDto;
using MyPortfolio.UI.Models.Dtos.ProductImageDto;
using Newtonsoft.Json;

namespace MyPortfolio.UI.ViewComponents.Default
{

	[AllowAnonymous]
	public class _ContentPartial : ViewComponent 
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _ContentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int categoryId)
		{
			 
			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync($"http://localhost:5185/api/Category/product{categoryId}");
			var responserMessage2 = await client.GetAsync($"http://localhost:5185/api/ProductImage");
			if (responserMessage.IsSuccessStatusCode && responserMessage2.IsSuccessStatusCode)
			{
				var jsonData = await responserMessage.Content.ReadAsStringAsync();
				var productValues = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				var imageJsonData = await responserMessage2.Content.ReadAsStringAsync();
				var imageValues = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(imageJsonData);
                foreach (var product in productValues)
                {
                    product.ProductImage = imageValues
                        .Where(img => img.ProductID == product.ProductID)
                        .ToList();
                }
                return View(productValues);
			}
			return View();
		}
	}
}
