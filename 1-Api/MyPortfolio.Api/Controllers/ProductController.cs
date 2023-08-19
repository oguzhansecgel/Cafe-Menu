using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		private readonly Context _context;
		public ProductController(IProductService productService, IMapper mapper, Context context)
		{
			_productService = productService;
			_mapper = mapper;
			_context = context;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _productService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddAProduct(AddProductDto addProductDto)
		{
			if (ModelState.IsValid)
			{
				var categoryExists = _context.Categories.Any(c => c.CategoryID == addProductDto.CategoryID);

				if (!categoryExists)
				{
					var errorMessage = $"{addProductDto.CategoryID} numarasına sahip kategori bulunamadı";
					return BadRequest(errorMessage);
				}
				var product = _mapper.Map<Product>(addProductDto);
 
				_productService.TInsert(product);

				return Ok();
			}
			return BadRequest();

		}
		[HttpDelete("{id}")]

		public IActionResult DeleteProduct(int id)
		{
			var values = _productService.TGetById(id);
			if (values == null) // gelen id değeri boş dönüyorsa
			{
				var errorResponse = new // hata
				{
					Error = "Urun Bulunamadi"
				};
				return new JsonResult(errorResponse)
				{
					StatusCode = 404
				};
			}
			_productService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var product = _mapper.Map<Product>(updateProductDto);
			_productService.TUpdate(product);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var values = _productService.TGetById(id);
			return Ok(values);
		}

	}
}
