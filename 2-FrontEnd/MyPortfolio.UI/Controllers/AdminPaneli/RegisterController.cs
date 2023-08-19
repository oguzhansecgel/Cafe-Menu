using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.Dtos.RegisterDto;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    [AllowAnonymous]

	public class RegisterController : Controller
    {
        private readonly UserManager<Appuser> _usermanager;
        
        public RegisterController(UserManager<Appuser> usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
 
            if(!ModelState.IsValid) 
            {
                return View();
            }
            var appUser = new Appuser()
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Email,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username,
            };
            var result = await _usermanager.CreateAsync(appUser,createNewUserDto.Password) ;
            if(result.Succeeded) 
            { 
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
