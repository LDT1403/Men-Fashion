using AutoMapper.Execution;
using AutoMapper;
using Men_Fashion.Repo.Model;
using Men_Fashion.Response;
using Men_Fashion.Request;

namespace Men_Fashion.Helper
{
    public class MapperHandle : Profile
    {
        public MapperHandle()
        {
            CreateMap<ProductRequest, Product>();
            CreateMap<ProductResponse, Product>().ReverseMap();
            CreateMap<CategoryRequest, Category>().ReverseMap();
            //CreateMap<Cart, CartResponse>()
            //    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            //    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            //    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            //    .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.Product.Thumbnail))
            //    .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src => src.Product.Inventory));

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
