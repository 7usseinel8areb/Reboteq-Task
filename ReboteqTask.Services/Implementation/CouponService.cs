namespace ReboteqTask.Services.Implementation;

internal class CouponService : ICouponService
{
    private readonly ICouponRepository _couponRepository;
    public CouponService(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }
    public async Task<Coupon?> GetCouponAsync(int couponId = 0)
    {
        if (couponId == 0)
            return null;
        return await _couponRepository.GetByIdAsync(couponId);
    }
}
