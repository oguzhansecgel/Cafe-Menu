using FluentValidation;
using MyPortfolio.Dtos.AboutDto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Validation.About
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutVM>
	{
        public CreateAboutValidator()
        {
			RuleFor(x => x.Title)
	.NotEmpty().WithMessage("Hakkında Başlığı Boş Bırakılamaz.")
	.MinimumLength(4).WithMessage("Hakkında Başlığı için Minumum 4 Karakter Veri Girişi Yapınız.");

			RuleFor(x => x.Description).NotNull().WithMessage("Hakkında Açıklaması Boş Bırakılamaz").MinimumLength(5).WithMessage("Hakkında Açıklaması için Minumum 4 Karakter Veri Girişi Yapınız.");
		}
    }
}
