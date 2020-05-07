using System;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories.Base;

namespace LojaVirtual.Infra.Repositories
{
    public class CouponRepository : RepositoryBase<Coupon, Guid>, ICouponRepository
    {
        public CouponRepository(DatabaseContext context) : base(context)
        {
        }
    }
}