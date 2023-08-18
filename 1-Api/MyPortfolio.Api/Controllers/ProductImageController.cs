using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.ProductImageDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductImageController : ControllerBase
	{
		private readonly IProductImageService _productImageService;
		private readonly Context _context;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

		public ProductImageController(IProductImageService productImageService, Context context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, IConfiguration configuration, IMapper mapper)
		{
			_productImageService = productImageService;
			_context = context;
			_environment = environment;
			_configuration = configuration;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductImageList()
		{
			var values = _productImageService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddProductImage([FromForm] AddProductImageWithProductDto model)
		{
			if (ModelState.IsValid)
			{
				var productExists = _context.Products.Any(c => c.ProductID == model.ProductID);

				if (!productExists)
				{
					var errorMessage = $"{model.ProductID} numarasına sahip ürün bulunamadı";
					return BadRequest(errorMessage);
				}
				var date = DateTime.Now;
				var extension = Path.GetExtension(model.UploadedImage.FileName);
				var fileName = $"{date.Day}_{date.Month}_{date.Year}_{date.Hour}_{date.Minute}_{date.Second}_{date.Millisecond}{extension}";
				var filePath = Path.Combine(_environment.ContentRootPath, _configuration["Paths:ProductImages"], fileName);

				using (FileStream fs = new FileStream(filePath, FileMode.Create))
				{
					model.UploadedImage.CopyTo(fs);
					fs.Close();
				}
				var productImageEntity = _mapper.Map<ProductImage>(model);
				productImageEntity.Path = Path.Combine(_configuration["Paths:ProductImages"], fileName);



				_productImageService.TInsert(productImageEntity);

				return Ok();
			}
			return BadRequest();

		}
	}
}
