namespace MyPortfolio.UI.Dtos.ProductDto
{
    public class UpdateProductDto
    {
        public int ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
       
        public int ProductImageID { get; set; }
        public int CategoryID { get; set; }

    }
}
