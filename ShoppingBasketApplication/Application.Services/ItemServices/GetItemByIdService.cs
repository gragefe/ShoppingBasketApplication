namespace Application.Services.ItemServices;

using Application.DTO;
using Application.Services.Interfaces.Item;
using Application.Services.Mappers;
using Domain.Model.Interfaces;
using System.Threading.Tasks;

public class GetItemByIdService : IGetItemByIdService
{
    private readonly IItemRepository _repository;

    public GetItemByIdService(
        IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Item>> GetByIdAsync(IEnumerable<Guid> ids)
    {
        var items = await _repository.GetByIdAsync(ids);

        return items.Select(i => i.ToDto());
    }
}