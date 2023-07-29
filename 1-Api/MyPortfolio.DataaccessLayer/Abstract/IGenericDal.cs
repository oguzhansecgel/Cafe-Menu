using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DataaccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		T GetById(int id);
		List<T> GetAll();
		void Insert(T t);
		void Update(T t);
		void Delete(T t);
	}
}
