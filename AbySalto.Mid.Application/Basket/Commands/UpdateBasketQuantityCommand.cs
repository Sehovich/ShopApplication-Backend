using MediatR;

public class UpdateBasketQuantityCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
