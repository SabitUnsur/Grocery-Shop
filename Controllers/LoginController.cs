using FoodCore.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodCore.Controllers
{
    public class LoginController : Controller
    {
        Context db=new Context();

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            var dataValue = db.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName
            && x.AdminPassword == admin.AdminPassword);

            if(dataValue != null) 
            { 
                var claims=new List<Claim>()
                {

                    new Claim(ClaimTypes.Name,admin.AdminUserName)

            
                };

                var userIdentity=new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal claimsPrincipal=new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("CategoryIndex","Category");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }


    }
}
