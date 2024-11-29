namespace Application.Services.Interfaces;

using Application.DTO;

public interface ISearchItemService
{
    Task<IEnumerable<Item>> SearechAsync(ItemSearchContext searchContext);
}