namespace ReboteqTask.Core.Entities;

public class Order
{
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalPriceAfterDiscount { get; set; }

    public int CouponId { get; set; } = 0;
    [ForeignKey(nameof(CouponId))]
    public Coupon? Coupon { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
}