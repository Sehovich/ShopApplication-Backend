using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
