namespace Presentation.Api.Controllers;
using Application.DTO;
using Application.Services.Interfaces.Item;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ISearchItemService _searchItemService;
    private readonly IGetItemByIdService _getItemByIdService;

    public ItemsController(ISearchItemService searchItemService, IGetItemByIdService getItemByIdService)
    {
        _searchItemService = searchItemService;
        _getItemByIdService = getItemByIdService;
    }

    [HttpGet(Name = "GetByIdAsync")]
    public async Task<ActionResult<IEnumerable<Item>>> GetByIdAsync([FromQuery] IEnumerable<Guid> ids)
    {
        return this.Ok(await _getItemByIdService.GetByIdAsync(ids));
    }

    [HttpPost(Name = "SearchAsync")]
    public async Task<ActionResult<Page<Item>>> SearchAsync([FromBody] ItemSearchContext searchContext)
    {
        return this.Ok(await _searchItemService.SearchAsync(searchContext));
    }
}