using ReboteqTask.Services.Abstract;

namespace ReboteqTask.Application.Features.Product.Query.Handler;

public class ProductHandler : ResponseHandler
    , IRequestHandler<GetAllProducts, Response<List<ProductResult>>>
{
    private readonly IProductService _productService;
    private IMapper _mapper;
    public ProductHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<Response<List<ProductResult>>> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _productService.GetAllProductsWithCategoryAsListAsync();

            var productsMapper = _mapper.Map<List<ProductResult>>(products);

            return Success(productsMapper);
        }
        catch (Exception ex)
        {
            return BadRequest<List<ProductResult>>(ex.InnerException.Message);
        }
    }
}
