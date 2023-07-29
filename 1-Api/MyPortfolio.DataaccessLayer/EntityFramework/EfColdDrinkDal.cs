using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.DataaccessLayer.Repository;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DataaccessLayer.EntityFramework
{
	public class EfColdDrinkDal : GenericRepository<ColdDrink>, IColdDrinkDal
	{
		public EfColdDrinkDal(Context context) : base(context)
		{
		}
	}
}
