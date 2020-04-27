using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IUserTokenRepository :
        IAddRepository<UserToken>,
        IGetByRepository<UserToken>,
        IUpdateRepository<UserToken>
    {
    }
}
