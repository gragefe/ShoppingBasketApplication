namespace Domain.Model.Interfaces;

using Domain.Model.Entities;

public interface IItemRepository
{
    Task<IEnumerable<Item>> SearchAsync(ItemSearchContext searchContext);
}