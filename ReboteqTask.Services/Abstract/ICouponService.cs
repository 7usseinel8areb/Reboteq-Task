namespace ReboteqTask.Services.Abstract;

public interface ICouponService
{
    Task<Coupon?> GetCouponAsync(int couponId);
}
