using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }
}