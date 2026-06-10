using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
    }
}