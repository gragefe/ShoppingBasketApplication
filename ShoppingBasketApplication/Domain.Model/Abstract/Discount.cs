namespace Domain.Model.Abstract;

public abstract class Discount
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int PercentOff { get; set; }

    public abstract void ApplyDiscount();
}