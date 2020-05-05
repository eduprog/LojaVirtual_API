using System;
using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;

namespace LojaVirtual.Domain.Commands.Cart.ListCart
{
    public class ListCartRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public Guid UserId { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(UserId.ToString(), "User", "Usuário é obrigatório")
            );
        }
    }
}