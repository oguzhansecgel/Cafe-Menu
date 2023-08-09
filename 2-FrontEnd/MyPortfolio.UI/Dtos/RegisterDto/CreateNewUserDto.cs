using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.UI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {

        [Required(ErrorMessage="Adınızı Giriz.")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Soyadınızı Giriz.")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Mail Adresinizi Giriz.")]
		public string Email { get; set; }
		
        [Required(ErrorMessage = "Kullanıcı Adınızı Giriz.")] 
        public string Username { get; set; }

		[Required(ErrorMessage = "Şifrenizi Giriz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Şifrenizin Tekrarını Giriz.")]
		public string ConfirmPassword { get; set; }
    }
}
