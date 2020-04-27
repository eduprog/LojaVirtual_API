using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IPlaceRepository :
        IListAndOrderByRepository<Place>
    {
    }
}
