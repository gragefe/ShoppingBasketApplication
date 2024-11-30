namespace Presentation.Api.DependencyInjection;

using Application.Services.BasketServices;
using Application.Services.Interfaces.Basket;

public static class BasketServices
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services
              .AddScoped<IGetBasketService, GetBasketService>();

        builder.Services
              .AddScoped<IAddBasketItemsService, AddBasketItemsService>();

        builder.Services
              .AddScoped<IUpdateBasketItemsService, UpdateBasketItemsService>();

        builder.Services
              .AddScoped<IRemoveBasketItemsService, RemoveBasketItemsService>();
    }
}