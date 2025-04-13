using AbySalto.Mid.Domain.Entities;

public interface IBasketItemRepository
{
    Task<List<BasketItem>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task AddAsync(BasketItem item, CancellationToken cancellationToken);
    Task RemoveAsync(int id, CancellationToken cancellationToken);
   

    Task RemoveByUserAndProductAsync(Guid userId, int productId, CancellationToken cancellationToken);

    Task MoveExpiredItemsToFavouritesAsync(CancellationToken cancellationToken);

    Task UpdateQuantityAsync(Guid userId, int productId, int quantity, CancellationToken cancellationToken);


}
