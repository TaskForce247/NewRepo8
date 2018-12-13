using MainClient.Core;
using System.Threading.Tasks;
using MainClient.Persistence;

namespace MainClient.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync() =>
            await _context.SaveChangesAsync();
    }
}
