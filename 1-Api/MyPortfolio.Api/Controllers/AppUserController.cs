using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.AppUserDto.RequestModel;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	
    public class AppUserController : ControllerBase
	{


		private readonly IAppUserService _appUserService;
		private readonly IMapper _mapper;
		private readonly Context _context;
		private readonly UserManager<Appuser> _userManager;
		public AppUserController(IAppUserService appUserService, IMapper mapper, Context context, UserManager<Appuser> userManager)
		{

			_appUserService = appUserService;
			_mapper = mapper;
			_context = context;
			_userManager = userManager;
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
			var usersExist = _context.Users.Any(x => x.Id == id);
			if (!usersExist)
			{
				var errorMessage = $"{id} kimlik numarasına sahip kullanıcı bulunamadı ve silme işlemi gerçekleşmedi";
				return BadRequest(errorMessage);
			}

			var values = _appUserService.TGetById(id);
			_appUserService.TDelete(values);
			return Ok();
		}

		[HttpPost("register")]

        public async Task<IActionResult> Register(RegisterViewModel registerDto)
		{

			var usersMail = _context.Users.Any(x => x.Email == registerDto.Email);
			var usersName = _context.Users.Any(x => x.UserName== registerDto.Username);
			 
			if (usersMail) 
			{
				var errorMessage = $"Girdiğiniz mail adresine kayıtlı kullanıcı bulunmakta";
				return BadRequest(errorMessage);

			}
			if (usersName)
			{
				var errorMessage = $"Girdiğiniz kullanıcı adı kullanılmaktadır.";
				return BadRequest(errorMessage);

			}
			if (registerDto.Password!=registerDto.ConfirmPassword)
			{
				var errorMessage = "Şifreler uyuşmuyor.";
				return BadRequest(errorMessage);
			}
			var appUser = _mapper.Map<Appuser>(registerDto);
			var result = await _userManager.CreateAsync(appUser, registerDto.Password);

			if (!result.Succeeded)
			{
				var errorMessages = result.Errors.Select(e => e.Description);
				return BadRequest(new { Errors = errorMessages });
			}

			return Ok();



		}


		[HttpPost("login")]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			 
			var user = await _userManager.FindByNameAsync(loginViewModel.Username);
			 
			if(user != null && await _userManager.CheckPasswordAsync(user, loginViewModel.Password))
			{
				return Ok();

			}
			else
			{
				var errorMessage = $"Girdiğiniz bilgiler yanlış";
				return BadRequest(errorMessage);
			}
		}

    

    }
}
