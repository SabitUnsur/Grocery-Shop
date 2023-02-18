using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FoodCore.Data.Models
{
	public class Food
	{
		[Key] public int FoodID { get; set; }
		public string FoodName { get; set; }
		[AllowNull] public string Description { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }
		public int Stock { get; set; }
		public int CategoryID { get; set; }
		public virtual Category Category { get; set; }
	}
}
