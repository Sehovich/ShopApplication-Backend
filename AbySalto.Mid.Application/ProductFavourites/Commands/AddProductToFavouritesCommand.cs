using MediatR;

namespace AbySalto.Mid.Application.ProductFavourites.Commands;

public class AddProductToFavouritesCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
}
