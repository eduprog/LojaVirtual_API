using LojaVirtual.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IGetByRepository<TEntity> : IRepositoryBase
        where TEntity : EntityBase
    {
        TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
