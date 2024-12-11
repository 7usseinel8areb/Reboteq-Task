namespace ReboteqTask.Services.Abstract;

public interface IProductService
{
    Task<List<Product>> GetAllProductsWithCategoryAsListAsync();
    Task<List<int>> GetExistingProductIdsAsync(ICollection<int> productIds);
    Task<List<Product>> GetProductsByIdsAsync(ICollection<int> products);
}
