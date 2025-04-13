using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json;

namespace AbySalto.Mid.Infrastructure.Services
{
    public class ProductImportService : IProductImportService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImportService(ShopDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _httpClientFactory = httpClientFactory;
        }

        public async Task ImportProductsAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContext.Products.Any()) return; 

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://dummyjson.com/products?limit=100", cancellationToken);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var root = JsonDocument.Parse(json).RootElement;

            var products = root.GetProperty("products").EnumerateArray()
                .Select(p => new Product
                {
                    Title = p.GetProperty("title").GetString()!,
                    Description = p.GetProperty("description").GetString()!,
                    Price = p.GetProperty("price").GetDecimal(),
                    Thumbnail = p.GetProperty("thumbnail").GetString()!,
                }).ToList();

            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
