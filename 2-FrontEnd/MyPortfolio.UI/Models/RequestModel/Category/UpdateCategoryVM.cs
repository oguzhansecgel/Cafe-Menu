using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.UI.Models.RequestModel.Category
{
	public class UpdateCategoryVM
    {
        public int CategoryID { get; set; }

		[Required(ErrorMessage = "Kategori Adı Boş Bırakılamaz.")]
		public string CategoryName { get; set; }
    }
}
