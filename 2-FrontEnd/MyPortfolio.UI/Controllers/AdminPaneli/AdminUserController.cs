using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Models.Dtos.UserDto;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5185/api/AppUser/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }

    }
}
