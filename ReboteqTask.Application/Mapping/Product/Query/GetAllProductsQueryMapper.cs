namespace ReboteqTask.Application.Mapping.Product;

public partial class ProductProfile
{
    public void GetAllProductsQueryMapper()
    {
        CreateMap<Entities.Product, ProductResult>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductPhoto, opt => opt.MapFrom(src => src.Photo));
    }
}
