namespace MyPortfolio.UI.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public int CategoryID { get; set; }

	}
}
