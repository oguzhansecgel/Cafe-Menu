using Microsoft.AspNetCore.Http;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.ProductImageDto
{
	public class AddProductImageWithProductDto
	{
 

		public int ProductID { get; set; }

		public IFormFile UploadedImage { get; set; }
	}
}
