namespace ReboteqTask.Application.Features.Product.Query.Results;

public class ProductResult
{
    public int Id { get; set; }

    public string ProductName { get; set; }

    public string? ProductPhoto { get; set; }

    public string ProductCategory { get; set; }

    public decimal ProductPrice { get; set; }
}
