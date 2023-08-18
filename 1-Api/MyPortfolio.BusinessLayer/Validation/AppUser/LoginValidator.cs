using FluentValidation;
using MyPortfolio.Dtos.AppUserDto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Validation.AppUser
{
	public class LoginValidator : AbstractValidator<LoginViewModel>
	{
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Boş Geçilemez");
        }
    }
}
 