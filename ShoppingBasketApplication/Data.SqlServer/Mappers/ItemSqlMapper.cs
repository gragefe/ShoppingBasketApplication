namespace Data.SqlServer.Mappers;

using DomainEntities = Domain.Model.Entities;
using SqlEntities = Data.SqlServer.Entities;

public static class ItemSqlMapper
    {
    public static DomainEntities.Item ToDomain(this SqlEntities.Item item)
    {
        if (item == null)
        {
            return null;
        }

        return new DomainEntities.Item
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Discounts = item.Discounts
        };
    }

    public static SqlEntities.Item ToSqlEntity(this DomainEntities.Item item)
    {
        if (item == null)
        {
            return null;
        }

        return new SqlEntities.Item
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Discounts = item.Discounts
        };
    }
}