
using System.ComponentModel.DataAnnotations;


namespace MyPortfolio.UI.Models.RequestModel.ProductImage
{
	public class AddProductImageVM
	{
		public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün Fotoğrafı Boş Geçilemez")]
        public IFormFile FileImage { get; set; }
 
	}
}
