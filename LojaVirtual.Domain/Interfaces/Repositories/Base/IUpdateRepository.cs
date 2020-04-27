using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IUpdateRepository<TEntity> : IRepositoryBase
        where TEntity : EntityBase
    {
        TEntity Update(TEntity entity);
    }
}
