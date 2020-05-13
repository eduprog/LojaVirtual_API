using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities.Base;
using LojaVirtual.Domain.Enums;

namespace LojaVirtual.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order(decimal totalProducts, decimal totalDiscount, decimal totalOrder, EOrderStatus status)
        {
            User = null;
            TotalProducts = totalProducts;
            TotalDiscount = totalDiscount;
            TotalOrder = totalOrder;
            Status = status;
            Items = new List<OrderItem>();
        }

        public User? User { get; private set; }
        public decimal TotalProducts { get; private set; }
        public decimal TotalDiscount { get; private set; }
        public decimal TotalOrder { get; private set; }
        public EOrderStatus Status { get; private set; }

        public IList<OrderItem> Items { get; private set; }

        public void SetTotalProducts(decimal total)
        {
            this.TotalProducts = total;
        }

        public void SetTotalDiscount(decimal total)
        {
            this.TotalDiscount = total;
        }

        public void SetTotalOrder(decimal total)
        {
            this.TotalOrder = total;
        }

        public void setUser(User user)
        {
            this.User = user;
        }
    }
}