using AbySalto.Mid.Application.Contracts.Basket;
using MediatR;

namespace AbySalto.Mid.Application.Basket.Queries;

public class GetBasketItemsQuery : IRequest<List<BasketItemDto>>
{
    public Guid UserId { get; set; }
}
