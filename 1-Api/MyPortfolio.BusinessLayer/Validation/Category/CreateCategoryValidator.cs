using FluentValidation;
using MyPortfolio.Dtos.CategoryDto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Validation.Category
{
    public class CreateCategoryValidator : AbstractValidator<AddCategoryVM>
	{
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori Adı Boş Bırakılmaz")
                .MinimumLength(4).WithMessage("En az 1 karakterlik veri girişi yapınız.");
        }
    }
}
