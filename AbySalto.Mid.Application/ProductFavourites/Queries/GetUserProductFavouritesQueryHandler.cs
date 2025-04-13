using AbySalto.Mid.Application.Contracts.ProductFavourites;
using AbySalto.Mid.Application.Interfaces;
using MediatR;

namespace AbySalto.Mid.Application.ProductFavourites.Queries;

public class GetUserProductFavouritesQueryHandler : IRequestHandler<GetUserProductFavouritesQuery, List<ProductFavouriteDto>>
{
    private readonly IProductFavouriteRepository _repository;

    public GetUserProductFavouritesQueryHandler(IProductFavouriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductFavouriteDto>> Handle(GetUserProductFavouritesQuery request, CancellationToken cancellationToken)
    {
        var favourites = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);

        return favourites.Select(static f => new ProductFavouriteDto
        {
            Id = f.Id,
            ProductId = f.ProductId,
            UserId = f.UserId
        }).ToList();
    }
}
