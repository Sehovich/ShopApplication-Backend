using AbySalto.Mid.Application.Interfaces;
using MediatR;

namespace AbySalto.Mid.Application.ProductFavourites.Commands;

public class RemoveProductFromFavouritesCommandHandler : IRequestHandler<RemoveProductFromFavouritesCommand, bool>
{
    private readonly IProductFavouriteRepository _repository;

    public RemoveProductFromFavouritesCommandHandler(IProductFavouriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RemoveProductFromFavouritesCommand request, CancellationToken cancellationToken)
    {
        return await _repository.RemoveAsync(request.UserId, request.ProductId, cancellationToken);
    }
}
