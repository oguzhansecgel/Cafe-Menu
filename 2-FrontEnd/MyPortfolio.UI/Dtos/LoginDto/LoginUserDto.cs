using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.UI.Dtos.LoginDto
{
	public class LoginUserDto
	{
		[Required(ErrorMessage ="Kullanıcı Adınızı Giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Şifrenizi Giriniz")]
		public string Password { get; set; }
	}
}
