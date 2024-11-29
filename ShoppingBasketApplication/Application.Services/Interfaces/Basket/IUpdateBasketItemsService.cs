namespace Application.Services.Interfaces.Basket;

using Application.DTO;

public interface IUpdateBasketItemsService
{
    Task<Basket> UpdateBasketItemsAsync(Dictionary<Guid, int> items);
}