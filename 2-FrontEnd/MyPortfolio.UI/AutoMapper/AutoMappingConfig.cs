using AutoMapper;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.Dtos.AboutDto;
using MyPortfolio.UI.Models.Dtos.CategoryDto;
using MyPortfolio.UI.Models.Dtos.LoginDto;
using MyPortfolio.UI.Models.Dtos.ProductDto;
using MyPortfolio.UI.Models.Dtos.ProductImageDto;
using MyPortfolio.UI.Models.Dtos.RegisterDto;
using MyPortfolio.UI.Models.Dtos.UserDto;
using MyPortfolio.UI.Models.RequestModel.About;
using MyPortfolio.UI.Models.RequestModel.Category;
using MyPortfolio.UI.Models.RequestModel.Role;

namespace MyPortfolio.UI.AutoMapper
{
	public class AutoMappingConfig : Profile 
	{

        public AutoMappingConfig()
        {
			CreateMap<ResultAboutDto, About>().ReverseMap();
			CreateMap<UpdateAboutVM, About>().ReverseMap();

			CreateMap<AddCategoryVM, Category>().ReverseMap();
			CreateMap<UpdateCategoryVM, Category>().ReverseMap();
			CreateMap<ResultCategoryDto, Category>().ReverseMap();


            CreateMap<ResultProductDto, Product>().ReverseMap();
			CreateMap<AddProductVM, Product>().ReverseMap();
			CreateMap<UpdateProductVM, Product>().ReverseMap();


			CreateMap<ResultProductImageDto, ProductImage>().ReverseMap();


            CreateMap<CreateNewUserDto, Appuser>().ReverseMap();
			CreateMap<LoginUserDto, Appuser>().ReverseMap();
			CreateMap<ResultUserDto, Appuser>().ReverseMap();
			CreateMap<UpdateUserDto, Appuser>().ReverseMap();

			CreateMap<RoleAssingVM, AppRole>().ReverseMap();

 

		}
    }
}
