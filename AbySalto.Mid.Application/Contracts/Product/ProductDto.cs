namespace AbySalto.Mid.Application.Contracts.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Thumbnail { get; set; } = default!;
    public decimal Price { get; set; }
}
