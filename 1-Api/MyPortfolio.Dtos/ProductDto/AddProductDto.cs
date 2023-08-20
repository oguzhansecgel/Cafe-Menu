using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.ProductDto
{
	public class AddProductDto
	{
		
		public decimal ProductPrice { get; set; }

		public string ProductName { get; set; }

		public string ProductDescription { get; set; }

		


		
		public int CategoryID { get; set; }
	}
}
