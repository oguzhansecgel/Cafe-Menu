using Microsoft.EntityFrameworkCore;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DataaccessLayer.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly Context _context;

		public GenericRepository(Context context)
		{
			_context = context;
		}
		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}
		public T GetByID(int id)
		{
			return _context.Set<T>().Find(id);
		}
		public void Delete(T t)
		{
			_context.Remove(t);
			_context.SaveChanges();
		}

		public void Insert(T t)
		{
			_context.Add(t);
			_context.SaveChanges();
		}

		public void Update(T t)
		{
			_context.Update(t);
			_context.SaveChanges();
		}

		
		
	}
}
