using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IProductRepository :
        IListAndOrderByRepository<Product>
    {
        IList<Product> Test(Guid CategoryId);
    }
}
