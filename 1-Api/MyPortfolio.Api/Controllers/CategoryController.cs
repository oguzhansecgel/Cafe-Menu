using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.CategoryDto.RequestModel;
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
		public IActionResult AddCategory(AddCategoryVM addCategoryDto)
		{
			if(ModelState.IsValid)
			{
				var category = _mapper.Map<Category>(addCategoryDto);
				_categoryService.TInsert(category);
				return Ok();
			}
			else
				return BadRequest();
			
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			var categoryId = _context.Categories.Any(x => x.CategoryID == id);
			if(!categoryId)
			{
				var errorMessage = $"{id} kimlik numarasına sahip kategori bulunamadı ve silme işlemi gerçekleşmedi";
				return BadRequest(errorMessage);
			}
			var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryVM updateCategoryDto)
		{
			var categoryId = _context.Categories.Any(x => x.CategoryID == updateCategoryDto.CategoryID);
			if (!categoryId)
			{
				var errorMessage = $"{updateCategoryDto.CategoryID} kimlik numarasına sahip kategori bulunamadı ve güncelleme işlemi gerçekleşmedi";
				return BadRequest(errorMessage);
			}
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
		[HttpGet("product{categoryId}")]
		public IActionResult GetProductsByCategoryId(int categoryId)
		{
			var products = _context.Products.Where(p => p.CategoryID == categoryId).ToList();
			return Ok(products);
		}

	}
}
