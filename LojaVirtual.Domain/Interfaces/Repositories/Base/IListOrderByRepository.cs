using LojaVirtual.Domain.Entities.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IListOrderByRepository<TEntity> : IRepositoryBase
        where TEntity : EntityBase
    {
        IQueryable<TEntity> ListOrderBy<TKey>(Expression<Func<TEntity, TKey>> order, bool asc = true, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
