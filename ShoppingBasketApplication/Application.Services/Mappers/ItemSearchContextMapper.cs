namespace Application.Services.Mappers;

using Domain = Domain.Model.Entities;

public static class ItemSearchContextMapper
{
    public static Domain.ItemSearchContext ToDomain(this DTO.ItemSearchContext searchContext)
    {
        if (searchContext == null)
        {
            return null;
        }

        return new Domain.ItemSearchContext
        {
            Name = searchContext.Name,
            Description = searchContext.Description,
            Price = searchContext.Price
        };
    }
}