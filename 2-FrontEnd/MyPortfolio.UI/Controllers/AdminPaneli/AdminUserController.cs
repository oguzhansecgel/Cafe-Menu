using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Dtos.AboutDto;
using MyPortfolio.UI.Dtos.UserDto;
using Newtonsoft.Json;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
	public class AdminUserController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminUserController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index() // listeleme metodu
		{
			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync("http://localhost:5185/api/AppUser");
			if (responserMessage.IsSuccessStatusCode)
			{
				var jsonData = await responserMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
				return View(values);
			}
			return View();

 
		}
	}
}
