using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Infra.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public IList<Product> Test(Guid CategoryId)
        {
            return this._context.Products.ToList();
        }
    }
}
