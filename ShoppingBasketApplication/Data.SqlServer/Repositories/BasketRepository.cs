namespace Data.SqlServer.Repositories;

using Data.SqlServer.Mappers;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

public class BasketRepository : IBasketRepository
{
    private readonly SqlDbContext _context;

    public BasketRepository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<Basket> GetAsync()
    {
        var basket = await _context.Baskets.FirstOrDefaultAsync();

        return basket.ToDomain();
    }

    public async Task<Basket> UpdateAsync(Basket updatedBasket)
    {
        var basket = await _context.Baskets.FirstOrDefaultAsync();

        basket = updatedBasket.ToSqlEntity();

        _context.Baskets.Update(basket);

        return basket.ToDomain();
    }
}