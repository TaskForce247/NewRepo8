using WaterLoggic.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterLoggic.Core;
using WaterLoggic.Persistence;

namespace WaterLoggic.Persistence
{
    public class CategoryRepository : IMCategoryRepository
    {
        private readonly WaterLogicDbContext _context;

        public CategoryRepository(WaterLogicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MCategory>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
