using FoodCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodCore.ViewComponents
{
	public class GetFoodList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository= new FoodRepository();
			var foodList = foodRepository.ElementList();
			return View(foodList);
		}
	}
}
