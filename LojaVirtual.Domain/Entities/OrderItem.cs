using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Entities
{
    public class OrderItem : EntityBase
    {
        public OrderItem(string size, int quantity, decimal price)
        {
            Order = null;
            Product = null;
            Size = size;
            Quantity = quantity;
            Price = price;
        }

        public Order Order { get; private set; }
        public Product Product { get; private set; }
        public string Size { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public void setOrder(Order order)
        {
            this.Order = order;
        }

        public void setProduct(Product product)
        {
            this.Product = product;
        }
    }
}