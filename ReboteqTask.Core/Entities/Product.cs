namespace ReboteqTask.Core.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Photo { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public decimal Price { get; set; }
}