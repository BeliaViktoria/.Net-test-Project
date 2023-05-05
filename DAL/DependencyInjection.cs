namespace DAL;

using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddDAL(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}