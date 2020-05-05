using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using System;

namespace LojaVirtual.Infra.Repositories
{
    public class CartRepository : RepositoryBase<Cart, Guid>, ICartRepository
    {
        public CartRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
