using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.UI.Models.RequestModel.Category
{
    public class AddCategoryVM
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Kategori İsmi Boş Bırakılamaz")]
        public string CategoryName { get; set; }
    }


}
