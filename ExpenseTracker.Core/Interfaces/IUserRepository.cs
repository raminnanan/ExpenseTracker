using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}