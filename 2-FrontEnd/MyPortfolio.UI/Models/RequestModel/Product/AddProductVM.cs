using System.ComponentModel.DataAnnotations;


namespace MyPortfolio.UI.Models.Dtos.ProductDto
{
    public class AddProductVM
    {
        public int ProductID { get; set; }

       [Required(ErrorMessage = "Ürün Fiyatı Boş Bırakılamaz.")]
       [Range(0.01, double.MaxValue, ErrorMessage = "Ürün Fiyatı 0'dan büyük olmalıdır.")]
        public decimal ProductPrice { get; set; }

       [Required(ErrorMessage = "Ürün Adı Boş Bırakılamaz.")]

        public string ProductName { get; set; }
       [Required(ErrorMessage = "Ürün Açıklaması Boş Bırakılamaz.")]

        public string ProductDescription { get; set; }

        [Required(ErrorMessage ="Kategori Boş Geçilemez")]
        public int CategoryID { get; set; }

    }
}

