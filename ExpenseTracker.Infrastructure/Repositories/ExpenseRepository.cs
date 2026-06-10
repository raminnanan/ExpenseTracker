using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Expense>> GetByUserIdAsync(int userId)
            => await _context.Expenses
                .Include(e => e.Category)
                .Where(e => e.UserId == userId)
                .ToListAsync();

        public async Task<IEnumerable<Expense>> GetByCategoryAsync(int categoryId)
            => await _context.Expenses
                .Where(e => e.CategoryId == categoryId)
                .ToListAsync();

        public async Task<IEnumerable<Expense>> GetByDateRangeAsync(int userId, DateTime from, DateTime to)
            => await _context.Expenses
                .Where(e => e.UserId == userId && e.Date >= from && e.Date <= to)
                .ToListAsync();

        public async Task<decimal> GetMonthlyTotalAsync(int userId, int month, int year)
            => await _context.Expenses
                .Where(e => e.UserId == userId
                         && e.Date.Month == month
                         && e.Date.Year == year)
                .SumAsync(e => e.Amount);
    }
}