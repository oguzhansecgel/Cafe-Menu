using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.Role;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> AddRole(AddRoleVM addRoleVM)
		{
			AppRole appRole = new AppRole()
			{
				Name = addRoleVM.RoleName,
			};
			var result = await _roleManager.CreateAsync(appRole);
			if(result.Succeeded) 
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> DeleteRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			UpdateRoleVM updateRoleVM = new UpdateRoleVM()
			{
				RoleId = value.Id,
				RoleName = value.Name

			};
			return View(updateRoleVM);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateRole(UpdateRoleVM updateRoleVM)
		{
			var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == updateRoleVM.RoleId);
			value.Name=updateRoleVM.RoleName;
			await _roleManager.UpdateAsync(value);
			return RedirectToAction("Index");
		}

    }
}
