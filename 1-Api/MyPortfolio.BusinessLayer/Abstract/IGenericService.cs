using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		T TGetById(int id);
		List<T> TGetAll();
		void TInsert(T t);
		void TUpdate(T t);
		void TDelete(T t);
	}
}
