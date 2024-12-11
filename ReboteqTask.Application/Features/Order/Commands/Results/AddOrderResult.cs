namespace ReboteqTask.Application.Features.Order.Commands.Results;

public class AddOrderResult
{
    public int OrderId { get; set; }

    public string? AppliedCoupon { get; set; }

    public int TotalItems { get; set; }

    public List<ProductResult> Items { get; set; } = new();

    public decimal TotalPrice { get; set; }

    public decimal TotalPriceAfterDiscount { get; set; }
}
