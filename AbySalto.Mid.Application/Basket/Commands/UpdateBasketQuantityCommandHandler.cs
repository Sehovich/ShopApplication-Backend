using MediatR;

public class UpdateBasketQuantityCommandHandler : IRequestHandler<UpdateBasketQuantityCommand, Unit>
{
    private readonly IBasketItemRepository _basketRepo;

    public UpdateBasketQuantityCommandHandler(IBasketItemRepository basketRepo)
    {
        _basketRepo = basketRepo;
    }

    public async Task<Unit> Handle(UpdateBasketQuantityCommand request, CancellationToken cancellationToken)
    {
        await _basketRepo.UpdateQuantityAsync(request.UserId, request.ProductId, request.Quantity, cancellationToken);
        return Unit.Value;
    }
}
