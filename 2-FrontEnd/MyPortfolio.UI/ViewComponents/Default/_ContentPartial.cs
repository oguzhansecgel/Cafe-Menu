using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Dtos.CategoryDto;
using MyPortfolio.UI.Dtos.ProductDto;
using Newtonsoft.Json;

namespace MyPortfolio.UI.ViewComponents.Default
{
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
            var responserMessage = await client.GetAsync($"http://localhost:5185/api/Category/products/{categoryId}");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
