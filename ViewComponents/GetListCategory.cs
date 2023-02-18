using FoodCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodCore.ViewComponents
{
    public class GetListCategory:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.ElementList();
            return View("Default",categoryList);
        }
    }
}
