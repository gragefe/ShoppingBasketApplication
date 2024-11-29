namespace Domain.Model.Interfaces;

using Domain.Model.Entities;

public interface IBasketRepository
{
    Task<Basket> GetAsync();

    Task<Basket> UpdateAsync(Basket basket);
}