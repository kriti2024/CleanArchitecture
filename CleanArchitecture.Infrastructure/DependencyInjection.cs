using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Application.Services1;
using CleanArchitecture.Infrastructure.Repositories1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderItemService, OrderItemService>();

        return services;
    }
}
