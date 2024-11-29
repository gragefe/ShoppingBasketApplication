namespace Application.DTO;

public class Basket
{
    public Basket()
    {
        Items = new Dictionary<Item, int>();
    }

    public Guid Id { get; set; }

    public Dictionary<Item, int> Items { get; set; }

    public double TotalPrice { get; set; }
}