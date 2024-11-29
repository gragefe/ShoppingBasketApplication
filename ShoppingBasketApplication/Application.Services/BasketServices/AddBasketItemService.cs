namespace Application.Services.BasketServices;

using Application.DTO;
using Application.Services.Interfaces.Basket;
using Application.Services.Mappers;
using Domain.Model.Interfaces;

public class AddBasketItemService : IAddBasketItemsService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IItemRepository _itemRepository;

    public AddBasketItemService(IBasketRepository basketRepository, IItemRepository itemRepository)
    {
        _basketRepository = basketRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Basket> AddBasketItemsAsync(Dictionary<Guid, int> items)
    {
        if (items == null || items.Count <= 0)
        {
            throw new ArgumentException("Items cant be empty.");
        }

        var basket = await _basketRepository.GetAsync();

        if (basket == null) throw new ArgumentException("inexistent bag.");

        var basketItems = await _itemRepository.GetByIdAsync(items.Keys);

        if (basketItems.Count() != items.Count) throw new ArgumentException("Some items are invalid.");

        foreach (var item in basketItems)
        {
            basket.UpdateItem(item, items[item.Id]);

            basket = await _basketRepository.UpdateAsync(basket);
        }

        return basket.ToDto();
    }
}