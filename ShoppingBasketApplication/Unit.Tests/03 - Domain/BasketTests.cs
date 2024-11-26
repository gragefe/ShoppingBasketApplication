namespace Unit.Tests._03___Domain;

using Domain.Model;
using Domain.Model.Abstract;
using System.Diagnostics;
using System.Xml.Linq;

public class BasketTests
{
    [Fact]
    public void ToDomain_NullVehicle_ReturnsNull()
    {
        // Arrange
        var expectedReceiptItem = new ReceiptItem
        {
            Name = "Name",
            OrignialPrice = 1,
            DiscountPercentOff = 10,
            FinalPrice = 0.90,
        };

        var expectedReceipt = new Receipt{
            Items = new List<ReceiptItem>
            {
                expectedReceiptItem
            }
        };
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = "Apples",
            Description = "item test",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 0.65
        };

        var itemQuantity = 1;

        var bagItems = new Dictionary<Item, int> { { item, itemQuantity } };

        var basket = new Basket(bagItems);

        // Act
        var result = basket.ProcessBasket();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Items);
        Assert.Equal(expectedReceiptItem.Name, result.Items.ElementAt(0).Name);
        Assert.Equal(expectedReceiptItem.OrignialPrice, result.Items.ElementAt(0).OrignialPrice);
        Assert.Equal(expectedReceiptItem.DiscountPercentOff, result.Items.ElementAt(0).DiscountPercentOff);
        Assert.Equal(expectedReceiptItem.FinalPrice, result.Items.ElementAt(0).FinalPrice);
    }
}