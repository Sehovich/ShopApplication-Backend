using MediatR;

namespace AbySalto.Mid.Application.Basket.Commands;

public class AddToBasketCommand : IRequest
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
}
