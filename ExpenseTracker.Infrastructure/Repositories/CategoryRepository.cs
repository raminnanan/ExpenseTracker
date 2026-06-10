using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category?> GetByNameAsync(string name)
            => await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }
}