namespace Domain.Model.Entities;

public class ReceiptItem
{
    public string Name { get; set; }

    public double OrignialPrice { get; set; }

    public int DiscountPercentOff { get; set; }

    public double FinalPrice { get; set; }
}