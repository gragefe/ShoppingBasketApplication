namespace Application.Services.Interfaces.Item;

using Application.DTO;

public interface ISearchItemService
{
    Task<Page<Item>> SearchAsync(ItemSearchContext searchContext);
}