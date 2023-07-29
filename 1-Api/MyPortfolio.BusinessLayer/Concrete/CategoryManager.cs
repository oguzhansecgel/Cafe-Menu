using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void TDelete(Category t)
		{
			_categoryDal.Delete(t);
		}

		public List<Category> TGetAll()
		{
			 return _categoryDal.GetAll();
		}

		public Category TGetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public void TInsert(Category t)
		{
			_categoryDal.Insert(t);
		}

		public void TUpdate(Category t)
		{
			_categoryDal.Update(t);
		}
	}
}
