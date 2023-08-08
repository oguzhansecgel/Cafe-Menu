using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.UI.Dtos.CategoryDto;
using Newtonsoft.Json;

namespace MyPortfolio.UI.ViewComponents.Default
{
    public class _CategoryPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _CategoryPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;

		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync("http://localhost:5185/api/Category");
			if (responserMessage.IsSuccessStatusCode)
			{
				var jsonData = await responserMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}




	}
}
