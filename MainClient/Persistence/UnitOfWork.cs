using MainClient.Core;
using System.Threading.Tasks;
using MainClient.Persistence;

namespace MainClient.Persistence
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
