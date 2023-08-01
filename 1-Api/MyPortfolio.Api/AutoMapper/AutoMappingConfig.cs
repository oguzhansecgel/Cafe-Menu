using AutoMapper;
using MyPortfolio.Dtos.CategoryDto;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.AutoMapper
{
	public class AutoMappingConfig : Profile
	{
        public AutoMappingConfig()
        {
            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();

            CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();



		}
    }
}
