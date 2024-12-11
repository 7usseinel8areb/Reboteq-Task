namespace ReboteqTask.Application.Features.Order.Commands.Handler;

public class ProductHandler : ResponseHandler,
    IRequestHandler<AddOrder, Response<AddOrderResult>>
{
    private readonly IOrderService _orderService;
    private readonly ICouponService _couponService;
    private readonly IProductService _productService;

    public ProductHandler(IOrderService orderService, IProductService productService, ICouponService couponService)
    {
        _orderService = orderService;
        _productService = productService;
        _couponService = couponService;
    }
    public async Task<Response<AddOrderResult>> Handle(AddOrder request, CancellationToken cancellationToken)
    {
        // Validate coupon
        var coupon = await _couponService.GetCouponAsync(request.CuponId);
        if (coupon == null)
        {
            return BadRequest<AddOrderResult>("Invalid coupon.");
        }

        // Get the products
        var products = await _productService.GetProductsByIdsAsync(request.Products);
        if (products.Count() == 0)
        {
            return BadRequest<AddOrderResult>("No valid products found.");
        }

        // Calculate the total price and apply discount
        var totalPrice = products.Sum(p => p.Price);
        var totalPriceAfterDiscount = totalPrice - (totalPrice * coupon.Discount / 100);

        // Create the order entity
        var order = new Entities.Order
        {
            CouponId = request.CuponId,
            OrderDetails = products.Select(p => new Entities.OrderDetail
            {
                ProductId = p.Id,
                Price = p.Price,
            }).ToList()
        };

        // Add the order to the database
        int orderId = await _orderService.AddOrderAsync(order);

        // Create the result to return
        var result = new AddOrderResult
        {
            OrderId = orderId,
            AppliedCoupon = coupon.Code,
            TotalItems = products.Count,
            Items = products.Select(p => new ProductResult
            {
                Id = p.Id,
                ProductName = p.Name,
                ProductPrice = p.Price
            }).ToList(),
            TotalPrice = totalPrice,
            TotalPriceAfterDiscount = totalPriceAfterDiscount
        };

        // Return a successful response with the result
        return Success(result);
    }
}
