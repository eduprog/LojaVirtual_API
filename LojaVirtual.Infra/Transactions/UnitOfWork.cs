using LojaVirtual.Infra.Repositories.Base;
using System.Threading.Tasks;

namespace LojaVirtual.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChanges()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
