using AutoMapper.Execution;
using AutoMapper;
using Men_Fashion.Repo.Models;

namespace Men_Fashion.Helper
{
    public class MapperHandle : Profile
    {
        public MapperHandle()
        {
            //    CreateMap<LoginModal, Member>().ReverseMap();
            //    CreateMap<ResProduct, Product>().ReverseMap();

            //    CreateMap<RequestProduct, Product>()
            //      .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            //      .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            //      .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            //      .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
            //      .ForMember(dest => dest.UnitsInStock, opt => opt.MapFrom(src => src.UnitsInStock));

        }
    }
}
