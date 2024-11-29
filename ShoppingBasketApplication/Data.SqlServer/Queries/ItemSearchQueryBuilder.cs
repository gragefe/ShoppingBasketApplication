namespace Data.SqlServer.Queries;

using SqlEntities = Data.SqlServer.Entities;
using DomainEntities = Domain.Model.Entities;

internal static class ItemSearchQueryBuilder
{
    internal static IQueryable<SqlEntities.Item> BuildSearchQuery(DomainEntities.ItemSearchContext searchContext, SqlDbContext db)
    {
        IQueryable<SqlEntities.Item> query = db.Items;

       if (!string.IsNullOrEmpty(searchContext.Name))
        {
            query = query.Where(c => c.Name.Contains(searchContext.Name));
        }

        if (!string.IsNullOrEmpty(searchContext.Description))
        {
            query = query.Where(c => c.Description == searchContext.Description);
        }

        if (searchContext.Price > 0)
        {
            query = query.Where(c => c.Price == searchContext.Price);
        }

        return query;
    }
}