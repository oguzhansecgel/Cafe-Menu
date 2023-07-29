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
	public class DessertManager : IDessertService
	{
		private readonly IDessertDal _dessertDal;

		public DessertManager(IDessertDal dessertDal)
		{
			_dessertDal = dessertDal;
		}

		public void TDelete(Dessert t)
		{
			_dessertDal.Delete(t);
		}

		public List<Dessert> TGetAll()
		{
			return _dessertDal.GetAll();
		}

		public Dessert TGetById(int id)
		{
			return _dessertDal.GetById(id);
		}

		public void TInsert(Dessert t)
		{
			_dessertDal.Insert(t);
		}

		public void TUpdate(Dessert t)
		{
			_dessertDal.Update(t);
		}
	}
}
