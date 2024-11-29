namespace Domain.Model.Entities;
public class Receipt
{
    public List<ReceiptItem> Items { get; set; }

    public double OriginalTotalPrice { get; set; }

    public double FinalTotalPrice { get; set; }
}