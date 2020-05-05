using LojaVirtual.Domain.Entities.Base;
using LojaVirtual.Domain.Enums;

namespace LojaVirtual.Domain.Entities
{
    public class Cart : EntityBase
    {
        public Cart(string size, int quantity, ECartOrigin origin)
        {
            Size = size;
            Quantity = quantity;
            Product = null;
            User = null;
            Origin = origin;
            Status = ECartStatus.Added;
        }

        public User User { get; private set; }
        public string Size { get; private set; }
        public int Quantity { get; private set; }
        public Product Product { get; private set; }
        public ECartOrigin Origin { get; private set; }
        public ECartStatus Status { get; private set; }

        public void setProduct(Product product)
        {
            this.Product = product;
        }

        public void setUser(User user)
        {
            this.User = user;
        }

        public void incrementQuantity()
        {
            this.Quantity++;
        }
    }
}
