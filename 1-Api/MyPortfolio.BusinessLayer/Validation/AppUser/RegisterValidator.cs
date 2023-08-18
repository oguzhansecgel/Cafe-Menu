using FluentValidation;
using MyPortfolio.Dtos.AppUserDto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Validation.AppUser
{
	public class RegisterValidator : AbstractValidator<RegisterViewModel>
	{
        public RegisterValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Isim alanı boş geçilemez");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");




            
            
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez").EmailAddress().WithMessage("Geçerli Bir Mail Adresi Giriniz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username alanı boş geçilemez")
                .MinimumLength(4).WithMessage("Minimum 4 karakterlik kullanıcı adı girişi yapınız")
                .MaximumLength(18).WithMessage("Maksimum 18 karakterlik kullanıcı adı girişi yapabilirsiniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez").Matches(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$").WithMessage("Parola en az bir büyük harf, bir rakam ve bir özel karakter içermelidir"); ;
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrarı boş geçilemez.");
        }
    }
}
//public string Name { get; set; }

//public string Surname { get; set; }

//public string Email { get; set; }

//public string Username { get; set; }

//public string Password { get; set; }

//public string ConfirmPassword { get; set; }