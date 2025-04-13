using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Infrastructure.Repositories;
using AbySalto.Mid.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbySalto.Mid.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddHttpClient<IProductProxyService, ProductProxyService>();
            services.AddScoped<IProductFavouriteRepository, ProductFavouriteRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddHostedService<ExpiredBasketItemsWorker>();


            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            return services;
        }
    }
}
