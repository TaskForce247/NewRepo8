using WaterLoggic.Core;
using System.Threading.Tasks;
using WaterLoggic.Persistence;

namespace CakeShop.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WaterLogicDbContext _context;

        public UnitOfWork(WaterLogicDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync() =>
            await _context.SaveChangesAsync();
    }
}
