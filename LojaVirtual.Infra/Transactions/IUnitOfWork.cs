using System.Threading.Tasks;

namespace LojaVirtual.Infra.Transactions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
