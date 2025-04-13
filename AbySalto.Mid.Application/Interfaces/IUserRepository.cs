using AbySalto.Mid.Domain.Entities;

namespace AbySalto.Mid.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
