namespace Application.Services.Interfaces.Basket;

using Application.DTO;

public interface IAddBasketItemsService
{
    Task<Basket> AddBasketItemsAsync(Dictionary<Guid, int> items);
}