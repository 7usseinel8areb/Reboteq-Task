using ReboteqTask.Services.Implementation;

namespace ReboteqTask.Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddTransient<ICouponService, CouponService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IOrderService, OrderService>();
        return services;
    }
}
