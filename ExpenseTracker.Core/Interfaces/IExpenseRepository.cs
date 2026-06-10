using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Core.Interfaces
{
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Expense>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Expense>> GetByDateRangeAsync(int userId, DateTime from, DateTime to);
        Task<decimal> GetMonthlyTotalAsync(int userId, int month, int year);
    }
}