using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class ProductImage
	{
		public int Id { get; set; }
		public string Path { get; set; }
 
		public int ProductID { get; set; }
		public Product Product { get; set; }	
	}
}
