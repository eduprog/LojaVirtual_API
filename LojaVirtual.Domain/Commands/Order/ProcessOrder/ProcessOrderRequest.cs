using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Commands.Order.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Commands.Order.ProcessOrder
{
    public class ProcessOrderRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public ProcessOrderRequest(Guid userId, string referenceDiscount, IList<CartItemModel> items)
        {
            UserId = userId;
            ReferenceDiscount = referenceDiscount;
            Items = items;
        }

        public Guid UserId { get; set; }
        public string ReferenceDiscount { get; set; }
        public IList<CartItemModel> Items { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(UserId.ToString(), "User", "Usuário é obrigatório")
            );
        }
    }
}
