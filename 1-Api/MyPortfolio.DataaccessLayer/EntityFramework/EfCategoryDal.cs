using Microsoft.EntityFrameworkCore;
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
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
	{

		public EfCategoryDal(Context context) : base(context)
		{

		}
 
	}
}
