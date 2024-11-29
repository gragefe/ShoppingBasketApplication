namespace Presentation.Api.Controllers;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ISearchItemService _searchItemService;
    public ItemsController(ISearchItemService searchItemService)
    {
        _searchItemService = searchItemService;
    }

    [HttpGet(Name = "SearchAsync")]
    public async Task<ActionResult<Page<Item>>> SearchAsync([FromBody] ItemSearchContext searchContext)
    {
        return this.Ok(await _searchItemService.SearchAsync(searchContext));
    }
}