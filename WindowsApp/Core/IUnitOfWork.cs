using System.Threading.Tasks;

namespace MainClient.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
