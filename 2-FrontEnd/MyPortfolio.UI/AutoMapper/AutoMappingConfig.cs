using AutoMapper;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Dtos.AboutDto;
using MyPortfolio.UI.Dtos.CategoryDto;
using MyPortfolio.UI.Dtos.LoginDto;
using MyPortfolio.UI.Dtos.ProductDto;
using MyPortfolio.UI.Dtos.ProductImageDto;
using MyPortfolio.UI.Dtos.RegisterDto;
using MyPortfolio.UI.Dtos.UserDto;
using MyPortfolio.UI.Models.Role;

namespace MyPortfolio.UI.AutoMapper
{
	public class AutoMappingConfig : Profile 
	{

        public AutoMappingConfig()
        {
			CreateMap<ResultAboutDto, About>().ReverseMap();
			CreateMap<UpdateAboutDto, About>().ReverseMap();

			CreateMap<AddCategoryDto, Category>().ReverseMap();
			CreateMap<UpdateCategoryDto, Category>().ReverseMap();
			CreateMap<ResultCategoryDto, Category>().ReverseMap();


			CreateMap<ResultProductDto, Product>().ReverseMap();
			CreateMap<AddProductDto, Product>().ReverseMap();
			CreateMap<UpdateProductDto, Product>().ReverseMap();

			CreateMap<ResultProductImageDto, ProductImage>().ReverseMap();

			CreateMap<CreateNewUserDto, Appuser>().ReverseMap();
			CreateMap<LoginUserDto, Appuser>().ReverseMap();
			CreateMap<ResultUserDto, Appuser>().ReverseMap();
			CreateMap<UpdateUserDto, Appuser>().ReverseMap();

			CreateMap<RoleAssingVM, AppRole>().ReverseMap();

		}
    }
}
