namespace Domain.Model.Entities;

using Domain.Model.Abstract;

public class DiscountMultiBuy : Discount
{
    public int MinimumItemQuantity { get; set; }

    public List<Guid> TargetItems { get; set; }

    public override void ApplyDiscount()
    {
        throw new NotImplementedException();
    }
}