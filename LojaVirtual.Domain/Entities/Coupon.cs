using System;
using Flunt.Validations;
using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Entities
{
    public class Coupon : EntityBase, IValidatable
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

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Reference, "Reference", "Cupom de desconto não informado!")
                .IsTrue(Active, "Active", "Cupom de desconto inválido")
            );

            if (ExpirationDate.HasValue && DateTime.Now >= ExpirationDate)
            {
                AddNotification("ExpirationDate", "Cupom de desconto expirado");
            }
        }
    }
}