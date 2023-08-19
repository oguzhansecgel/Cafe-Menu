using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.AboutDto.RequestModel;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]

	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;
		private readonly Context _context;
		public AboutController(IAboutService aboutService, IMapper mapper, Context context)
		{
			_aboutService = aboutService;
			_mapper = mapper;
			_context = context;
		}

		[HttpGet]
        public IActionResult AboutList()
		{
			var values = _aboutService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddAbout(CreateAboutVM aboutDto)
		{
			var about = _mapper.Map<About>(aboutDto);
			_aboutService.TInsert(about);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteAbout(int id)
		{
			var aboutExist = _context.Abouts.Any(x => x.AboutID == id);
			if (!aboutExist)
			{
				var errorMessage = $"{id} kimlik numarasına sahip about bulunamadı ve silme işlemi gerçekleşmedi";
				return BadRequest(errorMessage);
			}

			var values = _aboutService.TGetById(id);
			_aboutService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutVM aboutDto)
		{
			var aboutExist = _context.Abouts.Any(x => x.AboutID == aboutDto.AboutID);
			if(!aboutExist)
			{
				var errorMessage = $"{aboutDto.AboutID} kimlik numarasına sahip about bulunamadı ve güncelleme işlemi gerçekleşmedi";
				return BadRequest(errorMessage);
			}

			var about = _mapper.Map<About>(aboutDto);
			_aboutService.TUpdate(about);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var values = _aboutService.TGetById(id);
			return Ok(values);
		}
	}
}
