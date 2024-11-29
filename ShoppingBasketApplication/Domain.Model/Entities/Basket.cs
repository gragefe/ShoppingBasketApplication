namespace Domain.Model.Entities;

using Domain.Model.Enum;

public class Basket
{
    public Basket()
    {
        Items = new Dictionary<Item, int>();
    }

    public Guid Id { get; set; }

    private Dictionary<Item, int> Items { get; set; }

    private double TotalPrice { get; set; }

    public void AddItem(Item item, int quantity)
    {
        if (Items.ContainsKey(item)) throw new ArgumentException("Invalid operation, item already exists");
        if (quantity <= 0) throw new ArgumentException("Invalid quantity");

        Items[item] = quantity;

        ProcessBasket();
    }

    public void UpdateItem(Item item, int quantity)
    {
        if (!Items.ContainsKey(item)) throw new ArgumentException("Invalid operation, item doesn't exists");
        if (quantity <= 0) throw new ArgumentException("Invalid quantity");

        Items[item] = quantity;

        ProcessBasket();
    }

    public void RemoveItem(Item item)
    {
        if (!Items.ContainsKey(item)) throw new ArgumentException("Invalid operation, item doesn't exists");

        Items.Remove(item);

        ProcessBasket();
    }

    public Dictionary<Item, int> GetItems()
    {
        return Items;
    }

    public double GetTotalPrice()
    {
        return TotalPrice;
    }

    private void ProcessBasket()
    {
        TotalPrice = 0;

        foreach (var item in Items)
        {
            TotalPrice += item.Key.Price * item.Value;
        }
    }
}