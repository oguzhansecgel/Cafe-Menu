using FluentValidation;
using MyPortfolio.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Validation.Products
{
    public class CreateProductValidator : AbstractValidator<AddProductDto>
    {
        public CreateProductValidator()
        {

            #region productprice
            RuleFor(x => x.ProductPrice)
                .NotEmpty()
                .WithMessage("Ürün fiyatı boş bırakılamaz");
            #endregion


            #region productname
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Ürün Adı Boş Geçilemez");
            RuleFor(x => x.ProductName)
                .MinimumLength(1)
                .WithMessage("en az 1 karakter olması lazım");
            RuleFor(x => x.ProductName)
                .MaximumLength(50)
                .WithMessage("en fazla 50 karakter veri girişi yapılabilir");
            #endregion


            #region productdescription

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez")
                .MinimumLength(5).WithMessage("en az 1 veri girişi yapın")
                .MaximumLength(255).WithMessage("en fazla 255 karakterlik veri girişi yapılabilir");
            #endregion


          

            #region productToCategory

            RuleFor(x => x.CategoryID)
                .NotEmpty().WithMessage("Kategori idsi boş geçilemez");
            #endregion
        }
    }
}
