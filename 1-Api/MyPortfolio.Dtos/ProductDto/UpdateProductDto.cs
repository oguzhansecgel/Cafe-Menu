using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.ProductDto
{
	public class UpdateProductDto
	{
        public int ProductID { get; set; }

        public int ProductPrice { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public string ProductImage { get; set; }

		public int CategoryID { get; set; }
	}
}
