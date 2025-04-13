using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Entities;
using AbySalto.Mid.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Mid.Infrastructure.Services;

public class BasketService : IBasketService
{
    private readonly ShopDbContext _dbContext;

    public BasketService(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<BasketItem> GetUserBasket(Guid userId)
    {
        return _dbContext.BasketItems
            .Include(b => b.Product)
            .Where(b => b.UserId == userId)
            .ToList();
    }

    public void AddToBasket(Guid userId, int productId)
    {
        var basketItem = new BasketItem
        {
            UserId = userId,
            ProductId = productId
        };

        _dbContext.BasketItems.Add(basketItem);
        _dbContext.SaveChanges();
    }

    public bool RemoveFromBasket(Guid userId, int basketItemId)
    {
        var item = _dbContext.BasketItems.FirstOrDefault(b => b.Id == basketItemId && b.UserId == userId);
        if (item == null)
            return false;

        _dbContext.BasketItems.Remove(item);
        _dbContext.SaveChanges();
        return true;
    }
}
