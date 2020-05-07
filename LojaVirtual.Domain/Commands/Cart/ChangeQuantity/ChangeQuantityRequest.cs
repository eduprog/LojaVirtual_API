using System;
using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;

namespace LojaVirtual.Domain.Commands.Cart.ChangeQuantity
{
    public class ChangeQuantityRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public ChangeQuantityRequest(Guid id, Guid userId, Enums.ECartOperation operation)
        {
            Id = id;
            UserId = userId;
            Operation = operation;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Enums.ECartOperation Operation { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Cart", "Id é obrigatório")
                .IsNotNullOrEmpty(UserId.ToString(), "User", "Usuário é obrigatório")
                .IsNotNullOrEmpty(Operation.ToString(), "Operation", "Add/Rem é obrigatório")
            );
        }
    }
}