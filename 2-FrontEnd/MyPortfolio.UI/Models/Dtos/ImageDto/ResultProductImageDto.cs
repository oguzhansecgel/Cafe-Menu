using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.UI.Models.Dtos.ImageDto
{
	public class ResultProductImageDto
	{
		public int Id { get; set; }
		public string Path { get; set; }

		public int ProductID { get; set; }
		public Product Product { get; set; }
	}
}
