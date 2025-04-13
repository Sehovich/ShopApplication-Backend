namespace AbySalto.Mid.Domain.Entities;

public class BasketItem
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int ProductId { get; set; }

    public Product Product { get; set; } = default!;
}
