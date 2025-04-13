namespace AbySalto.Mid.Application.Contracts.Basket;

public class BasketItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Guid UserId { get; set; }
    public int Quantity { get; set; } 
    public DateTime CreatedAt { get; set; }
}
