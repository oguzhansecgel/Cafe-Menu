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
	public class HotDrinkManager : IHotDrinkService
	{
		private readonly IHotDrinkDal _hotdrinkDal; 
		public void TDelete(HotDrink t)
		{
			_hotdrinkDal.Delete(t);
		}

		public List<HotDrink> TGetAll()
		{
			return _hotdrinkDal.GetAll();
		}

		public HotDrink TGetById(int id)
		{
			return _hotdrinkDal.GetById(id);
		}

		public void TInsert(HotDrink t)
		{
			_hotdrinkDal.Insert(t);
		}

		public void TUpdate(HotDrink t)
		{
			_hotdrinkDal.Update(t);
		}
	}
}
