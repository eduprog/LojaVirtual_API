using LojaVirtual.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            UserCreate = null;
            Images = new List<ProductImage>();
            Sizes = new List<ProductSize>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; set; }
        public User UserCreate { get; private set; }

        public IList<ProductImage> Images { get; private set; }
        public IList<ProductSize> Sizes { get; private set; }
    }
}
