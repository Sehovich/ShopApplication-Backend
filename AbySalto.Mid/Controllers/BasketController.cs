using AbySalto.Mid.Application.Basket.Commands;
using AbySalto.Mid.Application.Basket.Queries;
using AbySalto.Mid.Application.BasketItems.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AbySalto.Mid.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddToBasketCommand command)
    {
        command.UserId = GetUserId();
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> Remove(int productId)
    {
        var userId = GetUserId();
        await _mediator.Send(new RemoveFromBasketCommand { UserId = userId, ProductId = productId });
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = GetUserId();
        var items = await _mediator.Send(new GetBasketItemsQuery { UserId = userId });
        return Ok(items);
    }

    [HttpPut("quantity")]
    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateBasketQuantityCommand command)
    {
        command.UserId = GetUserId(); 
        await _mediator.Send(command);
        return Ok();
    }


    private Guid GetUserId()
    {
        return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}
