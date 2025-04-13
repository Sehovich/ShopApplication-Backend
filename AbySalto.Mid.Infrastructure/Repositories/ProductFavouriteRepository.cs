using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Mid.Infrastructure.Repositories;

public class ProductFavouriteRepository : IProductFavouriteRepository
{
    private readonly ShopDbContext _context;

    public ProductFavouriteRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ProductFavourite favourite, CancellationToken cancellationToken)
    {
        _context.ProductFavourites.Add(favourite);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> RemoveAsync(Guid userId, int productId, CancellationToken cancellationToken)
    {
        var entity = await _context.ProductFavourites
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId, cancellationToken);

        if (entity == null)
            return false;

        _context.ProductFavourites.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }


    public async Task<bool> ExistsAsync(Guid userId, int productId, CancellationToken cancellationToken)
    {
        return await _context.ProductFavourites
            .AnyAsync(f => f.UserId == userId && f.ProductId == productId, cancellationToken);
    }

    public async Task<List<ProductFavourite>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.ProductFavourites
            .Where(f => f.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
