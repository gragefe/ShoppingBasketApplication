namespace Data.SqlServer.Repositories;

using Data.SqlServer.Mappers;
using Data.SqlServer.Queries;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Entities;
using System.Collections.Generic;

public class ItemRepository : IItemRepository
{
    private readonly SqlDbContext _context;

    public ItemRepository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<Item> CreateAsync(Item item)
    {
        var ItemData = item.ToSqlEntity();

        await _context.AddAsync(ItemData);
        await _context.SaveChangesAsync();

        return ItemData.ToDomain();
    }

    public async Task<IEnumerable<Item>> GetByIdAsync(IEnumerable<Guid> ids)
    {
        var items = await _context.Items
            .Where(item => ids.Contains(item.Id))
            .ToListAsync();

        return items.Select(i => i.ToDomain());
    }

    public async Task<Page<Item>> SearchAsync(ItemSearchContext searchContext)
    {
        var query = ItemSearchQueryBuilder.BuildSearchQuery(searchContext, _context);

        var totalItems = await query.CountAsync();

        var totalPages = (int)Math.Ceiling(totalItems / (double)searchContext.PageSize);

        var results = await query
            .Skip((searchContext.PageNumber - 1) * searchContext.PageSize)
            .Take(searchContext.PageSize)
            .ToListAsync();

        return new Page<Item>
        {
            CurrentPage = searchContext.PageNumber,
            TotalPages = totalPages,
            TotalItems = totalItems,
            Results = results.Select(x => x.ToDomain())
        };
    }
}