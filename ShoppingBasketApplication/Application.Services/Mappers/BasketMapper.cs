namespace Application.Services.Mappers;

using Domain = Domain.Model.Entities;

public static class BasketMapper
{
    public static Domain.Basket ToDomain(this DTO.Basket basket)
    {
        if (basket == null) return null;

        var newBasket = new Domain.Basket();
        
        newBasket.Id = basket.Id;

        foreach (var item in basket.Items)
        {
            newBasket.AddItem(item.Key.ToDomain(), item.Value);
        }

        return newBasket;
    }

    public static DTO.Basket ToDto(this Domain.Basket basket)
    {
        if (basket == null) return null;

        var newBasket = new DTO.Basket();

        var basketItems = basket.GetItems();

        foreach (var item in basketItems)
        {
            newBasket.Items.Add(item.Key.ToDto(), item.Value);
        }

        newBasket.Id = basket.Id;
        newBasket.TotalPrice = basket.GetTotalPrice();

        return newBasket;
    }
}