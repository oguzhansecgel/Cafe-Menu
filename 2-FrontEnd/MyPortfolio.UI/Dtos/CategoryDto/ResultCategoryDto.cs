using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.UI.Dtos.CategoryDto
{
	public class ResultCategoryDto
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }


		public ICollection<Product> Products { get; set; }


	}
}
