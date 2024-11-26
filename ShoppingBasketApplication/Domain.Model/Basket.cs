namespace Domain.Model;

using Domain.Model.Enum;

public class Basket
{
    public Basket(Dictionary<Item, int> Items)
    {
        this.Items = Items;
        this.Status = BasketStatus.Open;
    }

    public Guid Id { get; set; }

    private BasketStatus Status { get; set; }

    private Dictionary<Item, int> Items { get; set; }

    private Receipt Receipt { get; set; }

    private double TotalPrice { get; set; }

    public Receipt ProcessBasket()
    {
        throw new NotImplementedException();
    }
}