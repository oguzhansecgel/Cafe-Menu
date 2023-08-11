using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Dtos.LoginDto;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    [AllowAnonymous]

    public class LoginController : Controller
	{
		private readonly SignInManager<Appuser> _signInManager;

		public LoginController(SignInManager<Appuser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginUserDto loginUserDto)
		{
			if(ModelState.IsValid) 
			{
				var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
				if(result.Succeeded) 
				{
					return RedirectToAction("Index", "About");
				}
				else
				{
					return View();
				}
			}
			return View();
		}
	}
}
