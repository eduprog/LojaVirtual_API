using System;

namespace LojaVirtual.Domain.Commands.Order.Models
{
    public class CartItemModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public Guid ProductId { get; set; }
    }
}
