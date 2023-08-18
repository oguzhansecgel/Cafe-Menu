using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.Role;

namespace MyPortfolio.UI.Controllers.AdminPaneli
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleAssignController(UserManager<Appuser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssingVM> roleAssingVMS = new List<RoleAssingVM>();
            foreach (var item in roles)
            {
                RoleAssingVM model = new RoleAssingVM();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssingVMS.Add(model);
            }
            return View(roleAssingVMS);
        }
        [HttpPost]
        public async Task<IActionResult> AssingRole(List<RoleAssingVM> roleAssignVM)
        {
            var userid = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in roleAssignVM)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
