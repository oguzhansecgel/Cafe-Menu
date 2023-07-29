using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class ColdDrink
	{
		public int ColdDrinkID { get; set; }
		public int ColdDrinkPrice { get; set; }
		public string ColdDrinkName { get; set; }
		public string ColdDrinkDescription { get; set; }
		public string ColdDrinkImage { get; set; }

		public int CategoryID { get; set; }
		public Category Category { get; set; }
	}
}
