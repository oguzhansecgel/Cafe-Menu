using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.ProductDto
{
	public class AddProductDto
	{
		[Required(ErrorMessage = "Lütfen Fiyat Bilgisi Giriniz!")]
		public int ProductPrice { get; set; }

		[Required(ErrorMessage = "Lütfen Ürün Bilgisi Giriniz!")]
		public string ProductName { get; set; }

		[Required(ErrorMessage = "Lütfen Ürün Bilgisi Giriniz!")]

		public string ProductDescription { get; set; }

		[Required(ErrorMessage = "Lütfen Ürün Fotoğrafı Bilgisini Giriniz!")]
		public string ProductImage { get; set; }

		[Required(ErrorMessage = "Lütfen Ürün Kategori Bilgisi Giriniz!")]
		public int CategoryID { get; set; }
	}
}
