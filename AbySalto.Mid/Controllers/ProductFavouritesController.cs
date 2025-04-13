using AbySalto.Mid.Application.ProductFavourites.Commands;
using AbySalto.Mid.Application.ProductFavourites.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AbySalto.Mid.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductFavouritesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductFavouritesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserFavourites()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var guid))
            return Unauthorized();

        var favourites = await _mediator.Send(new GetUserProductFavouritesQuery { UserId = guid });
        return Ok(favourites);
    }

    [HttpPost]
    public async Task<IActionResult> AddToFavourites([FromBody] AddProductToFavouritesCommand command)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var guid))
            return Unauthorized();

        command.UserId = guid;

        await _mediator.Send(command);
        return Ok();
    }


    [HttpDelete("{productId}")]
    public async Task<IActionResult> RemoveFromFavourites(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var guid))
            return Unauthorized();

        await _mediator.Send(new RemoveProductFromFavouritesCommand
        {
            ProductId = productId,
            UserId = guid
        });

        return Ok();
    }
}
