using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AbySalto.Mid.Infrastructure;

public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
{
    public ShopDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();

      
        var connectionString = "Server=localhost,1433;Database=ShopDb;User Id=sa;Password=SaPassword123!;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new ShopDbContext(optionsBuilder.Options);
    }
}
