using System;
using System.Collections.Generic;
using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Commands.Order.Models;
using MediatR;

namespace LojaVirtual.Domain.Commands.Order.FinishOrder
{
    public class FinishOrderRequest : RequestBase, IRequest<ResponseGeneric>
    {
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