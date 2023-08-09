﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Dtos.RegisterDto;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        
        public RegisterController(UserManager<AppUser> usermanager)
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
            var appUser = new AppUser()
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
