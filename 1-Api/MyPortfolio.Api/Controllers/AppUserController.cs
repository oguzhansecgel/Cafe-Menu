using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
		private readonly IMapper _mapper;
        public AppUserController(IAppUserService appUserService, IMapper mapper)
        {

            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpGet]
		public IActionResult AppUserList()
		{
			var values = _appUserService.TGetAll();
			return Ok(values);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteAppUser(int id)
        {
            var values = _appUserService.TGetById(id);
            _appUserService.TDelete(values);
            return Ok();
        }
		 
	}
}
