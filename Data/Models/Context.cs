using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodCore.Data.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=EGEMEN\\SQLEXPRESS;database=DbFoodCore;integrated security=true;TrustServerCertificate=True");
		}
		public DbSet<Food> Foods { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Admin> Admins	{ get; set; }
	}
}
