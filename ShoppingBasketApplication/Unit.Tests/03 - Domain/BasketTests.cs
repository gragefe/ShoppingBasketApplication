namespace Unit.Tests._03___Domain;

using Domain.Model;
using Domain.Model.Abstract;
using System.Diagnostics;
using System.Xml.Linq;

public class BasketTests
{
    [Fact]
    public void Basket_CreateNewBaskt_ReturnsEmptyBasket()
    {
        // Arrange
        var basket = new Basket();

        // Act
        var basketItems = basket.GetItems();
        var basketTotalPrice = basket.GetTotalPrice();

        // Assert
        Assert.NotNull(basket);
        Assert.Null(basketItems);
        Assert.Equal(0, basketTotalPrice);
    }

    [Fact]
    public void AddItem_AddOneItem_ReturnsBasketWithOneItem()
    {
        // Arrange
        var basket = new Basket();

        var item = new Item {
            Id = Guid.NewGuid(),
            Name = "Soup",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 0.65
        };

        var itemQuantity = 1;

        // Act
        basket.AddItem(item, itemQuantity);

        var basktItems = basket.GetItems();
        var basketTotalPrice = basket.GetTotalPrice();

        // Assert
        Assert.NotNull(basket);
        Assert.Single(basktItems);
        Assert.True(basktItems.ContainsKey(item));
        Assert.Equal(0.65, basketTotalPrice);
    }

    [Fact]
    public void AddItem_AddMultipleItems_ReturnsBasketWithMultipleItems()
    {
        // Arrange
        var basket = new Basket();

        var item1 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Apples",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 1
        };

        var item2 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Bread",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 0.80
        };

        var item3 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Milk",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 1.30
        };

        var itemQuantity1 = 1;
        var itemQuantity2 = 2;
        var itemQuantity3 = 3;

        var expectedTotalPrice = ((item1.Price * itemQuantity1) + (item2.Price * itemQuantity2) + (item3.Price * itemQuantity3));

        // Act
        basket.AddItem(item1, itemQuantity1);
        basket.AddItem(item2, itemQuantity2);
        basket.AddItem(item3, itemQuantity3);

        var basktItems = basket.GetItems();
        var basketTotalPrice = basket.GetTotalPrice();

        // Assert
        Assert.NotNull(basket);

        Assert.True(basktItems.ContainsKey(item1));
        Assert.Equal(itemQuantity1, basktItems[item1]);

        Assert.True(basktItems.ContainsKey(item2));
        Assert.Equal(itemQuantity2, basktItems[item2]);

        Assert.True(basktItems.ContainsKey(item3));
        Assert.Equal(itemQuantity3, basktItems[item3]);

        Assert.Equal(expectedTotalPrice, basketTotalPrice);
    }

    [Fact]
    public void UpdateItem_UpdateExistentItem_ReturnsBasketWithUpdatedItem()
    {
        // Arrange
        var basket = new Basket();
        var expectedItemQuantity = 6;

        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Soup",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 0.65
        };

        var itemQuantity = 1;

        basket.AddItem(item, itemQuantity);

        var expectedBasketTotalPrice = item.Price * expectedItemQuantity;

        // Act
        basket.UpdateItem(item, expectedItemQuantity);

        var basktItems = basket.GetItems();
        var basketTotalPrice = basket.GetTotalPrice();

        // Assert
        Assert.NotNull(basket);
        Assert.Single(basktItems);
        Assert.True(basktItems.ContainsKey(item));
        Assert.Equal(expectedItemQuantity, basktItems[item]);
        Assert.Equal(expectedBasketTotalPrice, basketTotalPrice);
    }

    [Fact]
    public void RemoveItem_RemoveExistentItem_ReturnsBasketWithoutRemovedItem()
    {
        // Arrange
        var basket = new Basket();

        var item1 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Soup",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 0.65
        };

        var item2 = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Milk",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 1.3
        };

        var itemQuantity1 = 1;
        var itemQuantity2 = 2;

        basket.AddItem(item1, itemQuantity1);
        basket.AddItem(item2, itemQuantity2);

        var expectedBasketTotalPrice = item1.Price * itemQuantity1;

        // Act
        basket.RemoveItem(item2);

        var basktItems = basket.GetItems();
        var basketTotalPrice = basket.GetTotalPrice();

        // Assert
        Assert.NotNull(basket);
        Assert.Single(basktItems);
        Assert.True(basktItems.ContainsKey(item1));
        Assert.Equal(itemQuantity1, basktItems[item1]);
        Assert.False(basktItems.ContainsKey(item2));
        Assert.Equal(expectedBasketTotalPrice, basketTotalPrice);
    }
}