using AutoMapper;
using MyPortfolio.Dtos.AppUserDto;
using MyPortfolio.Dtos.CategoryDto;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.Dtos.RoleDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.AutoMapper
{
	public class AutoMappingConfig : Profile
	{
        public AutoMappingConfig()
        {
            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();

			CreateMap<AddProductDto, Category>()
			 .ForMember(x => x.CategoryID, y => y.MapFrom(e => e.CategoryID))
			 .ReverseMap();

			CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();

            CreateMap<AddRoleDto, AppRole>().ReverseMap();
		}
    }
}
