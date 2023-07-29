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
	public class FoodManager : IFoodService
	{
		private readonly IFoodDal _foodDal;

		public FoodManager(IFoodDal foodDal)
		{
			_foodDal = foodDal;
		}

		public void TDelete(Food t)
		{
			_foodDal.Delete(t);
		}

		public List<Food> TGetAll()
		{
			return _foodDal.GetAll();
		}

		public Food TGetById(int id)
		{
			return _foodDal.GetById(id);
		}

		public void TInsert(Food t)
		{
			_foodDal.Insert(t);
		}

		public void TUpdate(Food t)
		{
			_foodDal.Update(t);
		}
	}
}
