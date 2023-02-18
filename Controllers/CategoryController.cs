using FoodCore.Data.Models;
using FoodCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace FoodCore.Controllers
{
	public class CategoryController : Controller
	{
        CategoryRepository categoryRepository = new CategoryRepository();
		//[Authorize]
		public IActionResult CategoryIndex(string p)
		{
			if(!string.IsNullOrEmpty(p))
			{
				return View(categoryRepository.ListByCategory(c=>c.CategoryName==p));
			}

			return View(categoryRepository.ElementList());
		}

		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCategory(Category category) 
		{
			category.Status = true;
            categoryRepository.AddElement(category);
			return RedirectToAction("CategoryIndex", "Category");
		}

		[HttpGet]
		public IActionResult GetCategory(int categoryID)
		{
			var category=categoryRepository.GetElement(categoryID);
			return View("GetCategory",category);
		}

		[HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
			var categoryToUpdate = categoryRepository.GetElement(category.CategoryID);
			categoryToUpdate.CategoryName = category.CategoryName;
			categoryToUpdate.CategoryDescription = category.CategoryDescription;
			categoryToUpdate.Status = true;
			categoryRepository.UpdateElement(categoryToUpdate);
			return RedirectToAction("CategoryIndex");
		}


		//[HttpPost]
		public IActionResult DeleteCategory(int categoryID) 
		{ 
			var categoryToDelete=categoryRepository.GetElement(categoryID);
			categoryToDelete.Status = false;
			categoryRepository.UpdateElement(categoryToDelete); 
			return RedirectToAction("CategoryIndex");
		}



	}
}
