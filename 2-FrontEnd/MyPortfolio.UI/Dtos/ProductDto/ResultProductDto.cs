using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Dtos.ProductImageDto;

namespace MyPortfolio.UI.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }


     
        public ICollection<ProductImage> ProductImage { get; set; }


        public int CategoryID { get; set; }
    }

}
