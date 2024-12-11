namespace ReboteqTask.Infrastructure.Repositories;

internal class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private DbSet<Order> orders;
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
        orders = dbContext.Set<Order>();
    }
}
