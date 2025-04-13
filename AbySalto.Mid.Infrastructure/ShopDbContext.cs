using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Infrastructure;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<BasketItem> BasketItems => Set<BasketItem>();

    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasKey(p => p.Id);

        modelBuilder.Entity<BasketItem>().HasKey(b => b.Id);
        modelBuilder.Entity<BasketItem>()
            .HasOne(b => b.Product)
            .WithMany()
            .HasForeignKey(b => b.ProductId);
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

    }
}
