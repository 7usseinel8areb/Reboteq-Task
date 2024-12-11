namespace ReboteqTask.Application.Features.Order.Commands.Models;

public class AddOrder : IRequest<Response<AddOrderResult>>
{
    public AddOrder()
    {
        Products = new HashSet<int>();
    }
    public int CuponId { get; set; } = 0;

    public ICollection<int> Products { get; set; }
}
