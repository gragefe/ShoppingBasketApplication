namespace Presentation.Api.DependencyInjection;

using Application.Services.Interfaces.Item;
using Application.Services.ItemServices;

public static class ItemServices
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services
              .AddScoped<IGetItemByIdService, GetItemByIdService>();

        builder.Services
              .AddScoped<ISearchItemService, SearchItemService>();
    }
}