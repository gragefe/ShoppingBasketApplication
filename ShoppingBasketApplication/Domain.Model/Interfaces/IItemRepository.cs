namespace Domain.Model.Interfaces;

using Domain.Model.Entities;

public interface IItemRepository
{
    Task<Item> CreateAsync(Item item);

    Task<Page<Item>> SearchAsync(ItemSearchContext searchContext);
}