using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Ecomerce_test1.Controllers
{
    public class UserController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(
                                 RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]//from anchor tag
        public IActionResult NEw()
        {
            return View();
        }

        [HttpPost]//pree submit button
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NEw(string RoleName)
        {
            if (RoleName != null)
            {
                IdentityRole role = new IdentityRole(RoleName);
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    TempData["msg"] = result.Errors.FirstOrDefault().Description;
                }
            }
            ViewData["RoleName"] = RoleName;
            return View();
        }

     









        }




    }
