namespace Application.Services.Interfaces.Basket;

using Application.DTO;

public interface IRemoveBasketItemsService
{
    Task<Basket> RemoveBasketItemsAsync(List<Guid> items);
}