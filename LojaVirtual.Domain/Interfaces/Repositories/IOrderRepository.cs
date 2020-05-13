using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IOrderRepository  :
        IListAndOrderByRepository<Order>,
        IAddRepository<Order>,
        IGetByRepository<Order>,
        IUpdateRepository<Order>
    {
    }
}
