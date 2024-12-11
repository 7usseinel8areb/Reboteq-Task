namespace ReboteqTask.Services.Implementation;

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetAllProductsWithCategoryAsListAsync()
    {
        return await _productRepository.GetTableNoTracking()
                .Include(x => x.Category)
                .ToListAsync();
    }

    public async Task<List<int>> GetExistingProductIdsAsync(ICollection<int> productIds)
    {
        return await _productRepository.GetTableNoTracking()
            .Select(x => x.Id)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductsByIdsAsync(ICollection<int> products)
    {
        return await _productRepository.GetTableNoTracking()
            .Where(p => products.Contains(p.Id))
            .ToListAsync();
    }
}
