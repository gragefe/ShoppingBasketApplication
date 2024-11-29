namespace Application.Services.Interfaces.Basket;

using Application.DTO;

public interface IGetBasketService
{
    Task<Basket> GetAsync();
}