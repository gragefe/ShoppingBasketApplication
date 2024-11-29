namespace Application.Services.Interfaces.Item;

using Application.DTO;

public interface IGetItemByIdService
{
    Task<IEnumerable<Item>> GetByIdAsync(IEnumerable<Guid> ids);
}