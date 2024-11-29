namespace Data.SqlServer.Mappers;

using DomainEntities = Domain.Model.Entities;
using SqlEntities = Data.SqlServer.Entities;

public static class BasketSqlMapper
{
    public static DomainEntities.Basket ToDomain(this SqlEntities.Basket basket)
    {
        if (basket == null) return null;

        var newBasket = new DomainEntities.Basket();

        foreach (var item in basket.Items)
        {
            newBasket.AddItem(item.Key.ToDomain(), item.Value);
        }

        newBasket.Id = basket.Id;

        return newBasket;
    }

    public static SqlEntities.Basket ToSqlEntity(this DomainEntities.Basket basket)
    {
        if (basket == null) return null;

        var newBasket = new SqlEntities.Basket();

        var basketItems = basket.GetItems();

        foreach (var item in basketItems)
        {
            newBasket.Items.Add(item.Key.ToSqlEntity(), item.Value);
        }

        newBasket.Id = basket.Id;
        newBasket.TotalPrice = basket.GetTotalPrice();

        return newBasket;
    }
}