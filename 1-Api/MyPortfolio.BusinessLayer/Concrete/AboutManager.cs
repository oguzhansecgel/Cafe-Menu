using AutoMapper;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
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
		private readonly Context _context;
		public AboutManager(IAboutDal aboutdal, Context context)
		{
			_aboutdal = aboutdal;
			_context = context;
		}
		public List<About> TGetAll()
		{
			return _aboutdal.GetAll();
		}

		public About TGetById(int id)
		{
			return _aboutdal.GetByID(id);
		}

		public void TDelete(About t)
		{
			 
			_aboutdal.Delete(t);
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
