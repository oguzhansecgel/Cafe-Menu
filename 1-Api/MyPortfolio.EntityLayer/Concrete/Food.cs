using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
	public class Food
	{
        public int FoodID { get; set; }
        public int FoodPrice{ get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public string FoodImage { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
