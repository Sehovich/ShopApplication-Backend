using AbySalto.Mid.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetProductsQuery { Page = page, PageSize = pageSize });
        return Ok(result); 
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
        return result is null ? NotFound() : Ok(result);
    }
}
