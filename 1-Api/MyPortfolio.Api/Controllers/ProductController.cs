using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
		public IActionResult ProductList()
		{
			var values = _productService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddAProduct(AddProductDto addProductDto)
		{
			if(ModelState.IsValid)
			{
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
