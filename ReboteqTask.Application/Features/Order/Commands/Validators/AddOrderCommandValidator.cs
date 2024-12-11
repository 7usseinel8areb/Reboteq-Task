namespace ReboteqTask.Application.Features.Order.Commands.Validators;

public class AddOrderCommandValidator : AbstractValidator<AddOrder>
{
    private readonly ICouponService _couponService;
    private readonly IProductService _productService;

    public AddOrderCommandValidator(ICouponService couponService, IProductService productService)
    {
        _couponService = couponService;

        ApplyValidationRules();
        ApplyCustomValidationRules();
        _productService = productService;
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Products)
            .NotEmpty()
            .WithMessage("Products collection cannot be empty.");
    }

    private void ApplyCustomValidationRules()
    {
        RuleFor(x => x.CuponId)
            .MustAsync(async (couponId, cancellationToken) => await IsCouponValidAsync(couponId))
            .WithMessage("Invalid coupon ID.");

        RuleFor(x => x.Products)
            .MustAsync(async (products, cancellationToken) => await DoAllProductIdsExistAsync(products))
            .WithMessage("One or more product IDs are invalid.");
    }

    private async Task<bool> IsCouponValidAsync(int couponId)
    {
        var coupon = await _couponService.GetCouponAsync(couponId);
        return coupon != null;
    }

    private async Task<bool> DoAllProductIdsExistAsync(ICollection<int> productIds)
    {
        if (productIds == null || !productIds.Any())
            return false;

        var existingIds = await _productService.GetExistingProductIdsAsync(productIds);
        return productIds.All(id => existingIds.Contains(id));
    }
}
