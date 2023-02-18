using FoodCore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodCore.Controllers
{
    
    public class DefaultController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
		public IActionResult CategoryDetails(int categoryID) 
        {
            ViewBag.x = categoryID;
            return View();
        }
    }
}
