using AbySalto.Mid.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Mid.Infrastructure.Repositories;

public class BasketItemRepository : IBasketItemRepository
{
    private readonly ShopDbContext _dbContext;

    public BasketItemRepository(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BasketItem>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.BasketItems
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(BasketItem item, CancellationToken cancellationToken)
    {
        await _dbContext.BasketItems.AddAsync(item, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.BasketItems.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _dbContext.BasketItems.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task MoveExpiredItemsToFavouritesAsync(CancellationToken cancellationToken)
    {
        var expirationTime = DateTime.UtcNow.AddHours(-4);

        var expiredItems = await _dbContext.BasketItems
            .Where(x => x.CreatedAt < expirationTime)
            .ToListAsync(cancellationToken);

        foreach (var item in expiredItems)
        {
            var alreadyFavourited = await _dbContext.ProductFavourites
                .AnyAsync(f => f.ProductId == item.ProductId && f.UserId == item.UserId, cancellationToken);

            if (!alreadyFavourited)
            {
                _dbContext.ProductFavourites.Add(new ProductFavourite
                {
                    ProductId = item.ProductId,
                    UserId = item.UserId
                });
            }
        }

        _dbContext.BasketItems.RemoveRange(expiredItems);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }



    public async Task RemoveByUserAndProductAsync(Guid userId, int productId, CancellationToken cancellationToken)
    {
        var item = await _dbContext.BasketItems
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, cancellationToken);

        if (item != null)
        {
            _dbContext.BasketItems.Remove(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UpdateQuantityAsync(Guid userId, int productId, int quantity, CancellationToken cancellationToken)
    {
        var item = await _dbContext.BasketItems.FirstOrDefaultAsync(
            x => x.UserId == userId && x.ProductId == productId,
            cancellationToken
        );

        if (item != null)
        {
            item.Quantity = quantity;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
