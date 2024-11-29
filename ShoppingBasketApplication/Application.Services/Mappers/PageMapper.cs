namespace Application.Services.Mappers;

using Application.DTO;

public static class PageMapper
{
    public static DTO.Page<Item> ToDto(this Domain.Model.Entities.Page<Domain.Model.Entities.Item> page)
    {
        return new DTO.Page<Item>() 
        {
            CurrentPage = page.CurrentPage,
            PageSize = page.PageSize,
            Results = page.Results.Select(r => r.ToDto()),
            TotalItems = page.TotalItems,
            TotalPages = page.TotalPages
        };
    }
}