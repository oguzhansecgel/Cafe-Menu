using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.Dtos.CategoryDto;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			this.categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = categoryService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddCategory(AddCategoryDto addCategoryDto)
		{
			var category = _mapper.Map<Category>(addCategoryDto);
			categoryService.TInsert(category);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteCategory(int id)
		{
			var values = categoryService.TGetById(id);
			categoryService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateCategory(Category category)
		{
			categoryService.TUpdate(category);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			var values = categoryService.TGetById(id);
			return Ok(values);
		}
	}
}
