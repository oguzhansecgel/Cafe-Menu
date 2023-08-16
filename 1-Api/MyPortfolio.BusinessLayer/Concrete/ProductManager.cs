using AutoMapper;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;
		private readonly IMapper _mapper;
		public ProductManager(IProductDal productDal, IMapper mapper)
		{
			_productDal = productDal;
			_mapper = mapper;
		}

		public List<Product> TGetAll()
		{
			return _productDal.GetAll();
		}

		public Product TGetById(int id)
		{
			return _productDal.GetByID(id);
		}
		public void TDelete(Product t)
		{
			_productDal.Delete(t);
		}

		public void TInsert(Product t)
		{

			_productDal.Insert(t);
		}

		public void TUpdate(Product t)
		{
			_productDal.Update(t);
		}
 
    }
}
