namespace Domain.Model.Entities;

public class ItemSearchContext
{
    public ItemSearchContext(int? pageNumber = 1, int? pageSize = 5)
    {
        this.PageNumber = pageNumber ?? 1;
        this.PageSize = pageSize ?? 5;
    }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }
}