	 using FoodCore.Data.Models;
using FoodCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FoodCore.Controllers
{
	public class FoodController : Controller
	{
        FoodRepository foodRepository = new FoodRepository();
		Context db= new Context();
        public IActionResult Index(int page=1)
		{
			
			return View(foodRepository.ElementList("Category").ToPagedList(page,3));
		}

		[HttpGet]
		public IActionResult AddFood()
		{
			List<SelectListItem> values = (from a in db.Categories.ToList()
										   select new SelectListItem
										   {
											   Text=a.CategoryName,
											   Value=a.CategoryID.ToString()

										   }).ToList();
			
			ViewBag.value=values;

			return View();
		}

		[HttpPost]
		public IActionResult AddFood(Food food)
		{
            foodRepository.AddElement(food);
            return View();
		}

		public IActionResult DeleteFood(int foodID) 
		{
            foodRepository.DeleteElement(foodID);
			return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult GetFood(int foodID) 
		{ 
			var foodToGet=foodRepository.GetElement(foodID);
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();

			ViewBag.value1 = values;
            return View(foodToGet);
		
		}
	}
}
