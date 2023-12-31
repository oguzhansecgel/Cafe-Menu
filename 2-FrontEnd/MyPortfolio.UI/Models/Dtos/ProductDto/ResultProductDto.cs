﻿using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.Dtos.ImageDto;
 

namespace MyPortfolio.UI.Models.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
 
		public ICollection<ResultProductImageDto> ProductImage { get; set; }

		public int CategoryID { get; set; }
    }

}
