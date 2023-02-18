using FoodCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodCore.ViewComponents
{
	public class FoodListByCategory:ViewComponent
	{
		public IViewComponentResult Invoke(int categoryID)
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodList = foodRepository.ListByCategory(x=>x.CategoryID== categoryID);
			return View(foodList);
		}
	}
}
