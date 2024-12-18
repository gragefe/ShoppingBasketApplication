namespace Presentation.Api.Controllers;

using Application.DTO;
using Application.Services.Interfaces.Basket;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly IGetBasketService _getGetBasketService;
    private readonly IAddBasketItemsService _addBasketItemService;
    private readonly IUpdateBasketItemsService _updateBasketItemService;
    private readonly IRemoveBasketItemsService _removeBasketItemService;

    public BasketController(
        IGetBasketService getBasketService,
        IAddBasketItemsService addBasketItemService,
        IUpdateBasketItemsService updateBasketItemService,
        IRemoveBasketItemsService removeBasketItemService)
    {
        _getGetBasketService = getBasketService;
        _addBasketItemService = addBasketItemService;
        _updateBasketItemService = updateBasketItemService;
        _removeBasketItemService = removeBasketItemService;
    }

    [HttpGet, Route("")]
    public async Task<ActionResult<Basket>> GetAsync()
    {
        return this.Ok(await _getGetBasketService.GetAsync());
    }

    [HttpPost, Route("addItems")]
    public async Task<ActionResult<Basket>> AddBasketItemsAsync([FromBody] Dictionary<Guid, int> items)
    {
        return this.Ok(await _addBasketItemService.AddBasketItemsAsync(items));
    }

    [HttpPut, Route("updateItems")]
    public async Task<ActionResult<Basket>> UpdateBasketItemsAsync(Dictionary<Guid, int> items)
    {
        return this.Ok(await _updateBasketItemService.UpdateBasketItemsAsync(items));
    }

    [HttpDelete, Route("removeItems")]
    public async Task<ActionResult<Basket>> removeBasketItemsAsync(List<Guid> items)
    {
        return this.Ok(await _removeBasketItemService.RemoveBasketItemsAsync(items));
    }
}