using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface ICartRepository :
        IListAndOrderByRepository<Cart>,
        IAddRepository<Cart>,
        IGetByRepository<Cart>,
        IUpdateRepository<Cart>
    {
    }
}
