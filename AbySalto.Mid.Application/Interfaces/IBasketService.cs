using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Application.Interfaces;

public interface IBasketService
{
    List<BasketItem> GetUserBasket(Guid userId);
    void AddToBasket(Guid userId, int productId);
    bool RemoveFromBasket(Guid userId, int basketItemId);
}
