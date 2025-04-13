using AbySalto.Mid.Application.Contracts.Product;
using AbySalto.Mid.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ProductProxyService : IProductProxyService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductProxyService> _logger;

    public ProductProxyService(HttpClient httpClient, ILogger<ProductProxyService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<ProductDto>> GetProductsAsync(int skip, int limit)
    {
        var url = $"https://dummyjson.com/products?limit={limit}&skip={skip}";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var wrapper = JsonConvert.DeserializeObject<ProductApiResponse>(content)!;

        return wrapper.Products;
    }

    private class ProductApiResponse
    {
        public List<ProductDto> Products { get; set; } = new();
    }
}
