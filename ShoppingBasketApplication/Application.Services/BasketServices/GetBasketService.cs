namespace Application.Services.BasketServices;

using Application.DTO;
using Application.Services.Interfaces.Basket;
using Application.Services.Mappers;
using Domain.Model.Interfaces;

public class GetBasketService : IGetBasketService
{
    private readonly IBasketRepository _repository;

    public GetBasketService(
        IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Basket> GetAsync()
    {
        var basket = await _repository.GetAsync();

        return basket.ToDto();
    }
}