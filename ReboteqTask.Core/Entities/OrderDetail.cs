namespace ReboteqTask.Core.Entities;

public class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Product? Product { get; set; }

    public decimal Price { get; set; }
}