using LojaVirtual.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Commands.Cart.AddProductInCart
{
    public class AddProductInCartResponse
    {
        public Guid Id { get; private set; }
        public string Size { get; private set; }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        public Enums.ECartOrigin Origin { get; private set; }

        public AddProductInCartResponse(Guid id, string size, int quantity, Guid productId, ECartOrigin origin)
        {
            Id = id;
            Size = size;
            Quantity = quantity;
            ProductId = productId;
            Origin = origin;
        }
    }
}
