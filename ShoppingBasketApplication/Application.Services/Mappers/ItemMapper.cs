namespace Application.Services.Mappers;

using Domain = Domain.Model.Entities;

public static class ItemMapper
{
    public static Domain.Item ToDomain(this DTO.Item item)
    {
        if (item == null)
        {
            return null;
        }

        return new Domain.Item
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Discounts = item.Discounts
        };
    }

    public static DTO.Item ToDto(this Domain.Item item)
    {
        if (item == null)
        {
            return null;
        }

        return new DTO.Item
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Discounts = item.Discounts
        };
    }
}