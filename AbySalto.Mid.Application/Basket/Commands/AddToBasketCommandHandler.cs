using AbySalto.Mid.Application.Basket.Commands;
using AbySalto.Mid.Domain.Entities;
using MediatR;

namespace AbySalto.Mid.Application.BasketItems.Commands
{
    public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand>
    {
        private readonly IBasketItemRepository _repository;

        public AddToBasketCommandHandler(IBasketItemRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            var item = new BasketItem
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(item, cancellationToken);
        }
    }
}
