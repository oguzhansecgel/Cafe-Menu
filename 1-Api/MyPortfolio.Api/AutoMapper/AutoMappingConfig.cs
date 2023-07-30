using AutoMapper;
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
		}
    }
}
