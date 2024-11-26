namespace Domain.Model;

public class ReceiptItem
{
    public String Name { get; set; }

    public double OrignialPrice { get; set; }

    public int DiscountPercentOff { get; set; }

    public double FinalPrice { get; set; }
}