using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;
using System;

namespace LojaVirtual.Domain.Commands.Order.ListOrdersByUser
{
    public class ListOrdersByUserRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public ListOrdersByUserRequest(Guid userId)
        {
            UserId = userId;
        }

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
