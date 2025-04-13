using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Application.Interfaces;

public interface IProductFavouriteRepository
{
    Task AddAsync(ProductFavourite favourite, CancellationToken cancellationToken);
    Task<bool> RemoveAsync(Guid userId, int productId, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Guid userId, int productId, CancellationToken cancellationToken);
    Task<List<ProductFavourite>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);


}
