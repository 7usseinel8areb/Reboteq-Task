
namespace ReboteqTask.Services.Implementation;

internal class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<int> AddOrderAsync(Order order)
    {
        try
        {
            await _orderRepository.AddAsync(order);
        }
        catch (Exception ex)
        {
            order.Id = 0;
        }
        return order.Id;
    }
}
