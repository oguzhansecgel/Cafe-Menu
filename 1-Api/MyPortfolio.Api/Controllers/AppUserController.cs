using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.Dtos.AppUserDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserController : ControllerBase
	{


		private readonly IAppUserService _appUserService;

		public AppUserController(IAppUserService appUserService)
		{

			_appUserService = appUserService;
		}

		[HttpGet]
		public IActionResult AppUserList()
		{
			var values = _appUserService.TGetAll();
			return Ok(values);
		}

	}
}
