namespace Data.SqlServer.Entities;

public class Item
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<Guid> Discounts { get; set; }

    public double Price { get; set; }
}