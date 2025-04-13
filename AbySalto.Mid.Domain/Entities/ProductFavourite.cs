namespace AbySalto.Mid.Domain.Entities;

public class ProductFavourite
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }
    public int ProductId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
