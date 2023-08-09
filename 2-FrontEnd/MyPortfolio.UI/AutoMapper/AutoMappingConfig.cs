using AutoMapper;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Dtos.AboutDto;
using MyPortfolio.UI.Dtos.CategoryDto;
using MyPortfolio.UI.Dtos.LoginDto;
using MyPortfolio.UI.Dtos.ProductDto;
using MyPortfolio.UI.Dtos.RegisterDto;

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

			CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
			CreateMap<LoginUserDto, AppUser>().ReverseMap();

		}
    }
}
