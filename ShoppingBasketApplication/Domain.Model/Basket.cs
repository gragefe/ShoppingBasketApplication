namespace Domain.Model;

using Domain.Model.Enum;

public class Basket
{
    public Basket()
    {
        this.Items = new Dictionary<Item, int>();
    }

    public Guid Id { get; set; }

    private Dictionary<Item, int> Items { get; set; }

    private double TotalPrice { get; set; }

    public void AddItem(Item item, int quantity)
    {
        if (this.Items.ContainsKey(item)) throw new ArgumentException("Invalid operation, item already exists");
        if (quantity <= 0) throw new ArgumentException("Invalid quantity");

        this.Items[item] = quantity;

        ProcessBasket();
    }

    public void UpdateItem(Item item, int quantity)
    {
        if (!this.Items.ContainsKey(item)) throw new ArgumentException("Invalid operation, item doesn't exists");
        if (quantity <= 0) throw new ArgumentException("Invalid quantity");

        this.Items[item] = quantity;

        ProcessBasket();
    }

    public void RemoveItem(Item item)
    {
        if (!this.Items.ContainsKey(item)) throw new ArgumentException("Invalid operation, item doesn't exists");

        this.Items.Remove(item);

        ProcessBasket();
    }

    public Dictionary<Item, int> GetItems()
    {
        return this.Items;
    }

    public double GetTotalPrice()
    {
        return this.TotalPrice;
    }

    private void ProcessBasket()
    {
        this.TotalPrice = 0;

        foreach (var item in Items)
        {
            this.TotalPrice += (item.Key.Price * item.Value);
        }
    }
}