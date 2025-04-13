

using AbySalto.Mid.Application.Contracts.Basket;

using MediatR;

namespace AbySalto.Mid.Application.Basket.Queries;

public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQuery, List<BasketItemDto>>
{
    private readonly IBasketItemRepository _repository;

    public GetBasketItemsQueryHandler(IBasketItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BasketItemDto>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return items.Select(i => new BasketItemDto
        {
            Id = i.Id,
            ProductId = i.ProductId,
            UserId = i.UserId,
            Quantity = i.Quantity
        }).ToList();
    }
}
