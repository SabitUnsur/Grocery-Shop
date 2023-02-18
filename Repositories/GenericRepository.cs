using FoodCore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodCore.Repositories
{
	public class GenericRepository<T> where T : class,new()
	{
		Context db = new Context();

		public List<T> ElementList()
		{
			return db.Set<T>().ToList();
		}

		public void AddElement(T element)
		{
			db.Set<T>().Add(element);
			db.SaveChanges();
		}

		[HttpPost]
		public void DeleteElement(int elementID)
		{
			var elementToDelete = db.Set<T>().Find(elementID);
			db.Set<T>().Remove(elementToDelete);
			db.SaveChanges();
		}

		public void UpdateElement(T element)
		{
			db.Set<T>().Update(element);
			db.SaveChanges();
		}
		
		public T GetElement(int elementID)
		{
			var item=db.Set<T>().Find(elementID);
			return item;
		}

		public List<T> ElementList(string p)
		{
			return db.Set<T>().Include(p).ToList();
		}

		public List<T> ListByCategory(Expression<Func<T, bool>> filter)
		{
			return db.Set<T>().Where(filter).ToList();
		}

	}
}
