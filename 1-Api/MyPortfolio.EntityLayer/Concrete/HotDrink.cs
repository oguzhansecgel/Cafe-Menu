using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class HotDrink
	{
		public int HotDrinkID { get; set; }
		public int HotDrinkPrice { get; set; }
		public string HotDrinkName { get; set; }
		public string HotDrinkDescription { get; set; }
		public string HotDrinkImage { get; set; }

		public int CategoryID { get; set; }
		public Category Category { get; set; }
	}
}
