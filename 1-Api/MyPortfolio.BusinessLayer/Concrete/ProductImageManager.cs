﻿using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.Dtos.ProductImageDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.BusinessLayer.Concrete
{
	public class ProductImageManager : IProductImageService
	{
		private readonly IProductImageDal _productImageDal;

		public ProductImageManager(IProductImageDal productImageDal)
		{
			_productImageDal = productImageDal;
		}

		public List<ProductImage> TGetAll()
		{
			return _productImageDal.GetAll();
		}

		public ProductImage TGetById(int id)
		{
			return _productImageDal.GetByID(id);
		}
		public void TDelete(ProductImage t)
		{
			_productImageDal.Delete(t);
		}

		public void TInsert(ProductImage t)
		{
			_productImageDal.Insert(t);
		}

		public void TUpdate(ProductImage t)
		{
			_productImageDal.Update(t);
		}

		 
	}
}
