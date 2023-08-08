using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.UI.Dtos.CategoryDto
{
    public class AddCategoryDto
    {
		public int CategoryID { get; set; }

        [Required(ErrorMessage = "Ad Alanı Gereklidir..!")]
		public string CategoryName { get; set; }
    }


}
