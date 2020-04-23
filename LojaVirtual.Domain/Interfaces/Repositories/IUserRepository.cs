using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IUserRepository :
        IGetByRepository<User>,
        IAddRepository<User>
    {
    }
}
