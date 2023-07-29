using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Concrete
{
	public class ColdDrinkManager : IColdDrinkService
	{
		private readonly IColdDrinkDal _coldDrink;

		public ColdDrinkManager(IColdDrinkDal coldDrink)
		{
			_coldDrink = coldDrink;
		}

		public void TDelete(EntityLayer.Concrete.ColdDrink t)
		{
			_coldDrink.Delete(t);
		}

		public List<EntityLayer.Concrete.ColdDrink> TGetAll()
		{
			return _coldDrink.GetAll();
		}

		public EntityLayer.Concrete.ColdDrink TGetById(int id)
		{
			return _coldDrink.GetById(id);
		}

		public void TInsert(EntityLayer.Concrete.ColdDrink t)
		{
			_coldDrink.Insert(t);
		}

		public void TUpdate(EntityLayer.Concrete.ColdDrink t)
		{
			_coldDrink.Update(t);
		}
	}
}
