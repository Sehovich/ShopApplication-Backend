using AbySalto.Mid.Application.Contracts.Product;
using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly ShopDbContext _dbContext;

    public ProductService(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDto>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Thumbnail = p.Thumbnail
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var p = await _dbContext.Products.FindAsync(new object[] { id }, cancellationToken);
        return p is null ? null : new ProductDto
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Price = p.Price,
            Thumbnail = p.Thumbnail
        };
    }
}
