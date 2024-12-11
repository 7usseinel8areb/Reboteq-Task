namespace ReboteqTask.Infrastructure.Repositories;

internal class CouponRepository : GenericRepository<Coupon>, ICouponRepository
{
    private DbSet<Coupon> _coupons;
    public CouponRepository(AppDbContext dbContext) : base(dbContext)
    {
        _coupons = dbContext.Set<Coupon>();

    }
}
