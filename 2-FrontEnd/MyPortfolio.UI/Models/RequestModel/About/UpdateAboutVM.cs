using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace MyPortfolio.UI.Models.RequestModel.About
{
    public class UpdateAboutVM
    {
        public int AboutID { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Başlık Boş Bırakılamaz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakterlik veri girişi yapınız")]
        public string Title { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Açıklama Boş Bırakılamaz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakterlik veri girişi yapınız")]
        public string Description { get; set; }
    }
}
