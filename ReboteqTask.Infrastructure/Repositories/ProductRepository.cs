namespace ReboteqTask.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private DbSet<Product> _products;
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
        _products = dbContext.Set<Product>();
    }
}
