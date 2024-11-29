namespace Data.SqlServer.Repositories;

using Data.SqlServer.Mappers;
using Data.SqlServer.Queries;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Entities;

public class ItemRepository : IItemRepository
{
    private readonly SqlDbContext _context;

    public ItemRepository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> SearchAsync(ItemSearchContext searchContext)
    {
        var result = await ItemSearchQueryBuilder.BuildSearchQuery(searchContext, _context).ToListAsync();

        var items = new List<Item>();

        foreach (var item in result)
        {
            items.Add(item.ToDomain());
        }

        return items;
    }
}