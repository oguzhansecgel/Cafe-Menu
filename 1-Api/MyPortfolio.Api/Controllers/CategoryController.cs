using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.CategoryDto;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;		
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		private readonly Context _context;
		public CategoryController(ICategoryService categoryService, IMapper mapper, IProductService productService, Context context)
		{
			_categoryService = categoryService;
			_mapper = mapper;
			_productService = productService;
			_context = context;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _categoryService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddCategory(AddCategoryDto addCategoryDto)
		{
			var category = _mapper.Map<Category>(addCategoryDto);
            _categoryService.TInsert(category);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok();
        }
		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			var values = _categoryService.TGetById(id);

			return Ok(values);
		}

		// kategoriye göre ürün listeleme
		[HttpGet("products/{categoryId}")]
		public IActionResult GetProductsByCategoryId(int categoryId)
		{
			var products = _context.Products.Where(p => p.CategoryID == categoryId).ToList();
			return Ok(products);
		}

	}
}
