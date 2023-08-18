﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class Product
	{
		public int ProductID { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }


		public ICollection<ProductImage> ProductImages { get; set; }

		public int CategoryID { get; set; }
		public Category Category { get; set; }
	}
}
