using AbySalto.Mid.Application.Basket.Commands;
using MediatR;

namespace AbySalto.Mid.Application.BasketItems.Commands
{
    public class RemoveFromBasketCommandHandler : IRequestHandler<RemoveFromBasketCommand>
    {
        private readonly IBasketItemRepository _repository;

        public RemoveFromBasketCommandHandler(IBasketItemRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFromBasketCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByUserAndProductAsync(request.UserId, request.ProductId, cancellationToken);
        }
    }
}
