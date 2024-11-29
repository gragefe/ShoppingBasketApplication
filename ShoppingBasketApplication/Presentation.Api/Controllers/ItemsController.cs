namespace Presentation.Api.Controllers;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ISearchItemService _getItemService;
    public ItemsController(ISearchItemService getItemService)
    {
        _getItemService = getItemService;
    }

    [HttpGet(Name = "Search")]
    public async Task<ActionResult<Page<Item>>> SearechAsync([FromBody] ItemSearchContext searchContext)
    {
        return this.Ok(await _getItemService.SearechAsync(searchContext));
    }
}