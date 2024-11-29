namespace Application.Services.Interfaces;

using Application.DTO;

public interface ISearchItemService
{
    Task<Page<Item>> SearchAsync(ItemSearchContext searchContext);
}