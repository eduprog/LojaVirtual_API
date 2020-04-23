using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using System;

namespace LojaVirtual.Infra.Repositories
{
    public class BannerRepository : RepositoryBase<Banner, Guid>, IBannerRepository
    {
        public BannerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
