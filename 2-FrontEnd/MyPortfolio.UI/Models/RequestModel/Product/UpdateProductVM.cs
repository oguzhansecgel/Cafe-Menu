namespace MyPortfolio.UI.Models.Dtos.ProductDto
{
    public class UpdateProductVM
    {
        public int ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
 
        public int CategoryID { get; set; }

    }
}
