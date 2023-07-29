using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class Dessert
	{
		public int DessertID { get; set; }
		public int DessertPrice { get; set; }
		public string DessertName { get; set; }
		public string DessertDescription { get; set; }
		public string DessertImage { get; set; }

		public int CategoryID { get; set; }
		public Category Category { get; set; }
	}
}
