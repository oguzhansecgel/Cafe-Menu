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
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutdal;

		public AboutManager(IAboutDal aboutdal)
		{
			_aboutdal = aboutdal;
		}

		public void TDelete(About t)
		{
			_aboutdal.Delete(t);
		}

		public List<About> TGetAll()
		{
			return _aboutdal.GetAll();
		}

		public About TGetById(int id)
		{
			return _aboutdal.GetById(id);
		}

		public void TInsert(About t)
		{
			_aboutdal.Insert(t);
		}

		public void TUpdate(About t)
		{
			_aboutdal.Update(t);
		}
	}
}
