using FoodCore.Data;
using FoodCore.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodCore.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ColumnChart()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProductList());

        }

        public List<GoogleChart> ProductList()
        {
            List<GoogleChart> cs = new List<GoogleChart>();
            cs.Add(new GoogleChart()
            {
                productName = "Computer",
                productStock = 150
            });

            cs.Add(new GoogleChart()
            {
                productName = "USB",
                productStock = 220
            });

            cs.Add(new GoogleChart()
            {
                productName = "Lcd",
                productStock = 75
            });
            return cs;
        }


        public IActionResult DynamicChartIndex()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());

        }

        public List<GoogleChart2> FoodList()
        {

            List<GoogleChart2> cs2 = new List<GoogleChart2>();
            using (var c = new Context())   
            {
                cs2 = c.Foods.Select(f => new GoogleChart2()
                {
                    foodName = f.FoodName,
                    foodStock = f.Stock
                }).ToList();

            }
            return cs2;
        }

        public IActionResult Statistics()
        {
            Context db = new Context();

            var value1 = db.Foods.Count();
            ViewBag.v1 = value1;

            var value2 = db.Categories.Count();
            ViewBag.v2 = value2;


            var foodCategoryID = db.Categories.Where(f => f.CategoryName == "Fruit")
                .Select(x => x.CategoryID).FirstOrDefault();
            var value3 = db.Foods.Where(f => f.CategoryID == foodCategoryID).Count();
            ViewBag.v3 = value3;


            var value4 = db.Foods.Where(f => f.CategoryID == (db.Categories.Where(f => f.CategoryName == "Vegetable")
                .Select(x => x.CategoryID).FirstOrDefault())).Count();
            ViewBag.v4 = value4;

            var value5 = db.Foods.Sum(f => f.Stock);
            ViewBag.v5 = value5;


            var value6 = db.Foods.Where(f => f.CategoryID == (db.Categories.Where(f => f.CategoryName == "Legumes")
               .Select(x => x.CategoryID).FirstOrDefault())).Count();
            ViewBag.v6 = value6;

            var value7=db.Foods.OrderByDescending(f=>f.Stock).Select(f=>f.FoodName)
                .FirstOrDefault();
            ViewBag.v7 = value7;


            var value8 = db.Foods.OrderBy(f => f.Stock).Select(f => f.FoodName)
                .FirstOrDefault();
            ViewBag.v8 = value8;

            var value9 = db.Foods.Average(f => f.Price).ToString("0.00");
            ViewBag.v9 = value9;

            var value10p=db.Categories.Where(x=>x.CategoryName=="Fruit").Select(x=>x.CategoryID).FirstOrDefault();
            var value10 = db.Foods.Where(x => x.CategoryID == value10p).Sum(x => x.Stock);
            ViewBag.v10=value10;

            var value11p = db.Categories.Where(x => x.CategoryName == "Vegetable").Select(x => x.CategoryID).FirstOrDefault();
            var value11 = db.Foods.Where(x => x.CategoryID == value11p).Sum(x => x.Stock);
            ViewBag.v11 = value11;

            var value12= db.Foods.OrderByDescending(f => f.Price).Select(f => f.FoodName)
               .FirstOrDefault();
            ViewBag.v12 = value12;

            return View("Statistics");
        }


    }
}
