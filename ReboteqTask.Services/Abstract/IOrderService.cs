namespace ReboteqTask.Services.Abstract;

public interface IOrderService
{
    Task<int> AddOrderAsync(Order order);
}
