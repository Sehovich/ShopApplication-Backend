using AbySalto.Mid.Application.Contracts.Product;

public interface IProductProxyService
{
    Task<List<ProductDto>> GetProductsAsync(int skip, int limit);
}
