using AbySalto.Mid.Domain.Entities;
using AbySalto.Mid.Application.Interfaces;
using MediatR;

namespace AbySalto.Mid.Application.ProductFavourites.Commands;

public class AddProductToFavouritesCommandHandler : IRequestHandler<AddProductToFavouritesCommand, bool>
{
    private readonly IProductFavouriteRepository _repository;

    public AddProductToFavouritesCommandHandler(IProductFavouriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(AddProductToFavouritesCommand request, CancellationToken cancellationToken)
    {
        var exists = await _repository.ExistsAsync(request.UserId, request.ProductId, cancellationToken);
        if (exists) return false;

        var favourite = new ProductFavourite
        {
            UserId = request.UserId,
            ProductId = request.ProductId
        };

        await _repository.AddAsync(favourite, cancellationToken);
        return true;
    }
}
