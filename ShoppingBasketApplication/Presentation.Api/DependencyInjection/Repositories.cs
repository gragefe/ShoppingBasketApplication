namespace Presentation.Api.DependencieInjection;

using Data.SqlServer;
using Data.SqlServer.Repositories;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

public static class Repositories
{
    public static void AddRepositories(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration
            .GetSection("ConnectionStrings")
            .GetValue<string>("SqlServer");

        builder.Services
            .AddDbContext<SqlDbContext>(options => options
            .UseSqlServer(connectionString));

        builder.Services.AddScoped<IItemRepository, ItemRepository>();
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
    }
}