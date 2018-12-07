using System.Threading.Tasks;

namespace WaterLoggic.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
