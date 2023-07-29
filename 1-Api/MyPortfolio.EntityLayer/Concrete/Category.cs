using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class Category
	{
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Food> Food { get; set; }
        public ICollection<HotDrink> HotDrink { get; set; }
        public ICollection<ColdDrink> ColdDrink { get; set; }
        public ICollection<Dessert> Dessert { get; set; }

    }
}
