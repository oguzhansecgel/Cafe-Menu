using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace MyPortfolio.UI.Models.Dtos.AboutDto
{
    public class ResultAboutDto
    {
        public int AboutID { get; set; }
		[Required(ErrorMessage = "Başlığı Giriniz")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Açıklama Giriniz")]

		public string Description { get; set; }
    }
}
