using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Dtos.AboutDto;
using MyPortfolio.UI.Dtos.ProductDto;
using Newtonsoft.Json;

namespace MyPortfolio.UI.ViewComponents.Default
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5185/api/About");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
