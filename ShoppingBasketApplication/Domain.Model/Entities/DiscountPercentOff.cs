﻿namespace Domain.Model.Entities;

using Domain.Model.Abstract;

public class DiscountPercentOff : Discount
{
    public override void ApplyDiscount()
    {
        throw new NotImplementedException();
    }
}