using LojaVirtual.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IAddRepository<TEntity> : IRepositoryBase
        where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
    }
}
