using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoppingListDB context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return  await _context.Categories.Include(c => c.Products).ToListAsync();
        }
    }
}
