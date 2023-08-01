using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.CategoryDto
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
