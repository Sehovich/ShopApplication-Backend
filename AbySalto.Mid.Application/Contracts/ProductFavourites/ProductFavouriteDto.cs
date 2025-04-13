namespace AbySalto.Mid.Application.Contracts.ProductFavourites;

public class ProductFavouriteDto
{
    public Guid Id { get; set; }   
    public int ProductId { get; set; }
    public Guid UserId { get; set; }
}
