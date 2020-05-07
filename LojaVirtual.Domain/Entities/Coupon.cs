using System;
using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Entities
{
    public class Coupon : EntityBase
    {
        public Coupon(DateTime? expirationDate, string reference, decimal percent, bool active)
        {
            ExpirationDate = expirationDate;
            Reference = reference;
            Percent = percent;
            Active = active;
        }

        public DateTime? ExpirationDate { get; private set; }
        public string Reference { get; private set; }
        public decimal Percent { get; private set; }
        public bool Active { get; private set; }
    }
}