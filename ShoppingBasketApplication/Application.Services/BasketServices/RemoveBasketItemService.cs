namespace Application.Services.BasketServices;

using Application.DTO;
using Application.Services.Interfaces.Basket;
using Application.Services.Mappers;
using Domain.Model.Interfaces;

public class RemoveBasketItemsService : IRemoveBasketItemsService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IItemRepository _itemRepository;

    public RemoveBasketItemsService(IBasketRepository basketRepository, IItemRepository itemRepository)
    {
        _basketRepository = basketRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Basket> RemoveBasketItemsAsync(List<Guid> items)
    {
        if (items == null || items.Count <= 0)
        {
            throw new ArgumentException("Items cant be empty.");
        }

        var basket = await _basketRepository.GetAsync();

        if (basket == null) throw new ArgumentException("inexistent bag.");

        var basketItems = await _itemRepository.GetByIdAsync(items);

        if (basketItems.Count() != items.Count) throw new ArgumentException("Some items are invalid.");

        foreach (var item in basketItems)
        {
            basket.RemoveItem(item);

            basket = await _basketRepository.UpdateAsync(basket);
        }

        return basket.ToDto();
    }
}