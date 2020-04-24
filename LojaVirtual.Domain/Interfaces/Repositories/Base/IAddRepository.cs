using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IAddRepository<TEntity> : IRepositoryBase
        where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
    }
}
