using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Domain.Entities;
using AbySalto.Mid.Application.Interfaces;

namespace AbySalto.Mid.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShopDbContext _context;

    public UserRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

}
