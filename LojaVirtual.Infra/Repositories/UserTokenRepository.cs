using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using System;

namespace LojaVirtual.Infra.Repositories
{
    public class UserTokenRepository : RepositoryBase<UserToken, Guid>, IUserTokenRepository
    {
        public UserTokenRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
