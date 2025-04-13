namespace AbySalto.Mid.Domain.Entities;

public class BasketItem
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int ProductId { get; set; }

    public Product Product { get; set; } = default!;
}
