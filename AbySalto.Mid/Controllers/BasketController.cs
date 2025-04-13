using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Contracts.Basket;
using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet]
    public IActionResult GetBasketItems()
    {
        var userId = GetUserId();
        var items = _basketService.GetUserBasket(userId);
        return Ok(items);
    }

    [HttpPost]
    public IActionResult AddToBasket([FromBody] AddToBasketRequest request)
    {
        var userId = GetUserId();
        _basketService.AddToBasket(userId, request.ProductId);
        return Ok("Item added to basket.");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveFromBasket(int id)
    {
        var userId = GetUserId();
        var success = _basketService.RemoveFromBasket(userId, id);

        return success ? Ok("Item removed.") : NotFound();
    }

    private Guid GetUserId()
    {
        var subClaim = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        return Guid.Parse(subClaim!);
    }
}
