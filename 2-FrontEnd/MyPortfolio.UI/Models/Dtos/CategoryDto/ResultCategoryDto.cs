using MyPortfolio.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace MyPortfolio.UI.Models.Dtos.CategoryDto
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }
 
		public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}
