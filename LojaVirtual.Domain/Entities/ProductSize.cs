using LojaVirtual.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Entities
{
    public class ProductSize : EntityBase
    {
        public ProductSize(string size)
        {
            Size = size;
            Product = null;
            UserCreate = null;
        }

        public string Size { get; private set; }
        public Product Product { get; private set; }
        public User UserCreate { get; private set; }
    }
}
