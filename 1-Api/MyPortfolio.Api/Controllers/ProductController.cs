using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
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

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _productService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddAbout(AddProductDto addProductDto)
		{
			var product = _mapper.Map<Product>(addProductDto);
			_productService.TInsert(product);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteAbout(int id)
		{
			var values = _productService.TGetById(id);
			_productService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateAbout(Product product)
		{
			_productService.TUpdate(product);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var values = _productService.TGetById(id);
			return Ok(values);
		}
	}
}
