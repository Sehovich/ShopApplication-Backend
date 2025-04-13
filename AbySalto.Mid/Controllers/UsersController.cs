using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AbySalto.Mid.Application.Users.Queries;
using System.Security.Claims;

namespace AbySalto.Mid.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        Console.WriteLine("🔍 Listing user claims:");
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"➡️ Type: {claim.Type}, Value: {claim.Value}");
        }

        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userIdString))
        {
            Console.WriteLine("❌ 'nameidentifier' claim not found.");
            return Unauthorized("No identifier claim found in token.");
        }

        if (!Guid.TryParse(userIdString, out var userId))
        {
            Console.WriteLine($"❌ Unable to parse user ID: {userIdString}");
            return Unauthorized("Invalid user ID format.");
        }

        Console.WriteLine($"✅ User ID parsed from token: {userId}");

        var result = await _mediator.Send(new GetCurrentUserInfoQuery { UserId = userId });

        return Ok(result);
    }
}
