using AbySalto.Mid.Application.Contracts.Product;

public interface IProductService
{
    Task<List<ProductDto>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken);
    Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
