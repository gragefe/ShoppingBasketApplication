namespace Application.Services;

using Application.DTO;
using Application.Services.Interfaces;
using Application.Services.Mappers;
using Domain.Model.Interfaces;
using System.Threading.Tasks;

public class SearchItemService: ISearchItemService
{
    private readonly IItemRepository _repository;

    public SearchItemService(
        IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Page<Item>> SearchAsync(ItemSearchContext searchContext)
    {
        var result = await _repository.SearchAsync(searchContext.ToDomain());

        return result.ToDto();
    }
}