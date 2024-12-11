namespace ReboteqTask.Application;

public static class ModuleApplicationDependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Configuration of Mediator
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        //Configuration of AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Configuration of FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Register the ErrorHandlerMiddleware
        services.AddTransient<ErrorHandlerMiddleware>();

        return services;
    }
}