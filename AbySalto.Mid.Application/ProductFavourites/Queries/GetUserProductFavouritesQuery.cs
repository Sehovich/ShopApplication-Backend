
using AbySalto.Mid.Application.Contracts.ProductFavourites;
using MediatR;

namespace AbySalto.Mid.Application.ProductFavourites.Queries;

public class GetUserProductFavouritesQuery : IRequest<List<ProductFavouriteDto>>
{
    public Guid UserId { get; set; }
}
