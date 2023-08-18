using FluentValidation;
using MyPortfolio.Dtos.CategoryDto.RequestModel;

namespace MyPortfolio.BusinessLayer.Validation.Category
{
	public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryVM>
	{
        public UpdateCategoryValidator()
        {
			RuleFor(x => x.CategoryID)
				.NotEmpty().WithMessage("Güncellenecek olan kategori idsi boş bırakılmaz.")
				.GreaterThan(0).WithMessage("güncellenecek olan kategori kimlik bilgisi boş bırakılmaz.");
			RuleFor(x => x.CategoryName)
			   .NotEmpty().WithMessage("Kategori Adı Boş Bırakılmaz")
			   .MinimumLength(4).WithMessage("Kategori Adı için En az 1 karakterlik veri girişi yapınız.");
		}
    }
}
