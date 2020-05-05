using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.Transactions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
