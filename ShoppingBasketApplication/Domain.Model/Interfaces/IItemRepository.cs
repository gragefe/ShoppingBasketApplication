namespace Domain.Model.Interfaces;

using Domain.Model.Entities;

public interface IItemRepository
{
    Task<Item> CreateAsync(Item item);

    Task<IEnumerable<Item>> GetByIdAsync(IEnumerable<Guid> ids);

    Task<Page<Item>> SearchAsync(ItemSearchContext searchContext);
}