using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traversal.UI.Areas.Admin.Models;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            AppRole role = new()
            {
                Name = model.RoleName
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var deletedId = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(deletedId);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var editedId = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            EditRoleViewModel model = new()
            {
                RoleID = editedId.Id,
                RoleName = editedId.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRole)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == editRole.RoleID);
            value.Name = editRole.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            var userList = _userManager.Users.ToList();
            return View(userList);
        }

        public async Task<IActionResult> AssingRole(int id)
        {
            var users = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserId"] = users.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(users);
            List<AssignRoleViewModel> list = new List<AssignRoleViewModel>();
            foreach (var item in roles)
            {
                AssignRoleViewModel model = new AssignRoleViewModel();

                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                list.Add(model);
            }
            return View(list);
        }

        [HttpPost]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> assignRoles)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x=>x.Id == userId);
            foreach (var item in assignRoles)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,item.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }

    }
}
