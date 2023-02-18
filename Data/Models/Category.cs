using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FoodCore.Data.Models
{
	public class Category
	{
		[Key] public int CategoryID { get; set; }
        
		//[Required(ErrorMessage ="Category Empty Not Be Empty")] 
		public string CategoryName { get; set; }
		[AllowNull] public string CategoryDescription { get; set; }
		public bool Status { get; set; }
		public List<Food> Foods { get; set; }


	}
}
